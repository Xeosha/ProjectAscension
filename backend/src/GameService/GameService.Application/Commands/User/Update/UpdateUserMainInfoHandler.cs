using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.User.Update
{
    public class UpdateUserMainInfoHandler : ICommandHandler<Guid, UpdateUserMainInfoCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUserCharactersRepository _userCharactersRepository;
        private readonly IValidator<UpdateUserMainInfoCommand> _validator;
        private readonly ILogger<UpdateUserMainInfoHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserMainInfoHandler(
            IUsersRepository usersRepository,
            IUserCharactersRepository userCharactersRepository,
            IValidator<UpdateUserMainInfoCommand> validator,
            ILogger<UpdateUserMainInfoHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _userCharactersRepository = userCharactersRepository;
            _validator = validator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid, ErrorList>> Handle(UpdateUserMainInfoCommand command, CancellationToken cancellationToken = default)
        {

            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }


            var user = UserEntity.Create(
                command.Name,
                command.Email,
                command.UserName
                );

            user.Id = command.Id;

            var result = await _usersRepository.Update(user);

            if (!result.IsSuccess)
                return result.Error.ToErrorList();

            await _unitOfWork.SaveChanges();

            _logger.LogInformation("Updated user {name} with id {id}", user.UserName, user.Id);

            return user.Id;
        }
    }
}
