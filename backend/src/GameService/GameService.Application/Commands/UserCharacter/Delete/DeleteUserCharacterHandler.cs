using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using GameService.CORE.Interfaces;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.UserCharacter.Delete
{

    public class DeleteUserCharacterHandler : ICommandHandler<Guid, DeleteUserCharacterCommand>
    {
        private readonly IUserCharactersRepository _usersRepository;
        private readonly IValidator<DeleteUserCharacterCommand> _validator;
        private readonly ILogger<DeleteUserCharacterHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCharacterHandler(
            IUserCharactersRepository usersRepository,
            IValidator<DeleteUserCharacterCommand> validator,
            ILogger<DeleteUserCharacterHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _validator = validator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid, ErrorList>> Handle(
            DeleteUserCharacterCommand command,
            CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var result = await _usersRepository.Delete(command.Id);

            if (result.IsFailure)
                return result.Error.ToErrorList();

            await _unitOfWork.SaveChanges();

            var user = result.Value;

            _logger.LogInformation("Deleted userCharacter with id {user.Id}", user.Id);

            return user.Id;
        }

    }
}
