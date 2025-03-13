using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using GameService.CORE.Interfaces;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.UserCharacter.Update
{
    public class UpdateUserCharacterHandler : ICommandHandler<Guid, UpdateUserCharacterCommand>
    {
        private readonly IUserCharactersRepository _repository;
        private readonly IUsersRepository _usersRepository;
        private readonly IProffesionsRepository _proffesionsRepository;
        private readonly ITeamsRepository _teamsRepository;
        private readonly IValidator<UpdateUserCharacterCommand> _validator;
        private readonly ILogger<UpdateUserCharacterHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCharacterHandler(
            IUserCharactersRepository repository,
            IUsersRepository usersRepository,
            IProffesionsRepository proffesionsRepository,
            ITeamsRepository teamsRepository,
            IValidator<UpdateUserCharacterCommand> validator,
            ILogger<UpdateUserCharacterHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _usersRepository = usersRepository;
            _proffesionsRepository = proffesionsRepository;
            _teamsRepository = teamsRepository;
            _validator = validator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid, ErrorList>> Handle(UpdateUserCharacterCommand command, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var proffesionResult = await _proffesionsRepository.GetById(command.ProffesionId);
            var userResult = await _usersRepository.GetById(command.UserId);
            var teamResult = await _teamsRepository.GetById(command.UserId);


            if (!proffesionResult.IsSuccess || !userResult.IsSuccess || !teamResult.IsSuccess)
                return proffesionResult.Error.ToErrorList();

            var entityResult = await _repository.GetById(command.Id);

            if (!entityResult.IsSuccess)
                return entityResult.Error.ToErrorList();

            var entity = entityResult.Value;

            entity.UpdateTeam(teamResult.Value);
            entity.UpdateProffesion(proffesionResult.Value);
            entity.UpdateUser(userResult.Value);


            await _unitOfWork.SaveChanges();

            return entity.Id;
        }
    }
}
