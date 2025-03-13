using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.Team.Create
{
    public class CreateTeamHandler : ICommandHandler<Guid, CreateTeamCommand>
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IUserCharactersRepository _userCharactersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateTeamCommand> _validator;
        private readonly ILogger<CreateTeamHandler> _logger;

        public CreateTeamHandler(
            ITeamsRepository teamsRepository,
            IUserCharactersRepository userCharactersRepository,
            IUnitOfWork unitOfWork,
            IValidator<CreateTeamCommand> validator,
            ILogger<CreateTeamHandler> logger)
        {
            _teamsRepository = teamsRepository;
            _userCharactersRepository = userCharactersRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result<Guid, ErrorList>> Handle(CreateTeamCommand command, CancellationToken cancellationToken = default)
        {

            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var teamResult = TeamEntity.Create(command.Name, command.UserId);
            if (!teamResult.IsSuccess)
                return teamResult.Error.ToErrorList();

            var team = teamResult.Value;

            foreach (var characterId in command.CharacterIds)
            {
                var characterResult = await _userCharactersRepository.GetById(characterId);

                if (!characterResult.IsSuccess)
                    return characterResult.Error.ToErrorList();

                var character = characterResult.Value;

                if (character.UserId != command.UserId)
                    return Errors.General.ValueIsInvalid($"Character {characterId} doesn't belong to user").ToErrorList();

                var addResult = team.AddCharacter(character);

                if (addResult.IsFailure)
                    return Errors.General.ValueIsInvalid($"AddCharacter {characterId} dont add to team {team.Id}").ToErrorList();
            }

            await _teamsRepository.Add(team);

            await _unitOfWork.SaveChanges();

            _logger.LogInformation("Created team {name} with id {id}", team.Name, team.Id);

            return team.Id;
        }
    }
}
