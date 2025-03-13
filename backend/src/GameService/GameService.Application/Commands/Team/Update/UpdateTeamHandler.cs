using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.Team.Update
{
    public class UpdateTeamHandler : ICommandHandler<Guid, UpdateTeamCommand>
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IUserCharactersRepository _userCharactersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateTeamCommand> _validator;
        private readonly ILogger<UpdateTeamHandler> _logger;

        public UpdateTeamHandler(
            ITeamsRepository teamsRepository,
            IUserCharactersRepository userCharactersRepository,
            IUnitOfWork unitOfWork,
            IValidator<UpdateTeamCommand> validator,
            ILogger<UpdateTeamHandler> logger)
        {
            _teamsRepository = teamsRepository;
            _userCharactersRepository = userCharactersRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result<Guid, ErrorList>> Handle(UpdateTeamCommand command, CancellationToken cancellationToken = default)
        {

            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }


            var teamResult = await _teamsRepository.GetById(command.Id);

            if (!teamResult.IsSuccess)
                return teamResult.Error.ToErrorList();

            var team = teamResult.Value;

            team.Name = command.Name;

            foreach (var characterId in command.DeleteCharacters)
            {
                var characterResult = await _userCharactersRepository.GetById(characterId);

                if (!characterResult.IsSuccess)
                    return characterResult.Error.ToErrorList();

                var character = characterResult.Value;

                if (character.UserId != team.UserId)
                    return Errors.General.ValueIsInvalid($"Character {characterId} doesn't belong to user").ToErrorList();

                var removeResult = team.RemoveCharacter(character);

                if (removeResult.IsFailure)
                    return Errors.General.ValueIsInvalid($"DeleteCharacter {characterId} dont delete in team {team.Id}").ToErrorList();
            }

            foreach (var characterId in command.AddCharacters)
            {
                var characterResult = await _userCharactersRepository.GetById(characterId);

                if (!characterResult.IsSuccess)
                    return characterResult.Error.ToErrorList();

                var character = characterResult.Value;

                if (character.UserId != team.UserId)
                    return Errors.General.ValueIsInvalid($"Character {characterId} doesn't belong to user").ToErrorList();

                var addResult = team.AddCharacter(character);

                if (addResult.IsFailure)
                    return Errors.General.ValueIsInvalid($"AddCharacter {characterId} dont add to team {team.Id}").ToErrorList();
            }

            await _unitOfWork.SaveChanges();

            _logger.LogInformation("Updated team {name} with id {id}", team.Name, team.Id);

            return team.Id;
        }
    }

}
