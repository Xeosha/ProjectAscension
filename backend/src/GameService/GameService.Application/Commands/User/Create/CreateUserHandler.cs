using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using GameService.CORE.Interfaces;
using Microsoft.Extensions.Logging;
using GameService.CORE.DTO;

namespace GameService.Application.Commands.User.Create
{
    public class CreateUserHandler : ICommandHandler<Guid, CreateUserCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IValidator<CreateUserCommand> _validator;
        private readonly ILogger<CreateUserHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(
            IUsersRepository usersRepository,
            IValidator<CreateUserCommand> validator,
            ILogger<CreateUserHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _validator = validator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid, ErrorList>> Handle(CreateUserCommand command, CancellationToken cancellationToken = default)
        {

            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var entity = UserEntity.Create(
                command.Name,
                command.Email,
                command.UserName
                );

            await _usersRepository.Add(entity);

            await _unitOfWork.SaveChanges();

            _logger.LogInformation("Created user {name} with id {id}", entity.UserName, entity.Id);

            return entity.Id;
        }
    }
}
