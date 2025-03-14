using CSharpFunctionalExtensions;
using GameService.CORE.Common;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
namespace GameService.Application.Commands.UserCharacter.SwitchUser
{
    public class SwitchUserHandler : ICommandHandler<Guid, SwitchUserCommand>
    {
        private readonly IUserCharactersRepository _repository;
        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SwitchUserHandler(IUsersRepository usersRepository, IUserCharactersRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _usersRepository = usersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid, ErrorList>> Handle(SwitchUserCommand command, CancellationToken cancellationToken = default)
        {
            var characterResult = await _repository.GetById(command.Id);

            if (!characterResult.IsSuccess)
                return characterResult.Error.ToErrorList();

            var userResult = await _usersRepository.GetById(command.UserId);

            if (!userResult.IsSuccess)
                return userResult.Error.ToErrorList();


            var character = characterResult.Value;
            var user = userResult.Value;

            character.SwitchUser(user);


            await _unitOfWork.SaveChanges();

            return character.Id;

        }
    }
}
