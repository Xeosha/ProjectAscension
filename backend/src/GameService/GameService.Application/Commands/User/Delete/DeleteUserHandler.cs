using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.User.Delete
{
    public class DeleteUserHandler : ICommandHandler<Guid, DeleteUserCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IValidator<DeleteUserCommand> _validator;
        private readonly ILogger<DeleteUserHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(
            IUsersRepository usersRepository,
            IValidator<DeleteUserCommand> validator,
            ILogger<DeleteUserHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _validator = validator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid, ErrorList>> Handle(
            DeleteUserCommand command,
            CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var result = await _usersRepository.Delete(command.UserId);

            if (result.IsFailure)
                return result.Error.ToErrorList();

            await _unitOfWork.SaveChanges();

            var user = result.Value;

            _logger.LogInformation("Deleted user with id {user.Id}", user.Id);

            return user.Id;
        }

    }
}
