using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.UserCharacter.Create
{
    public class CreateUserCharacterHandler : ICommandHandler<Guid, CreateUserCharacterCommand>
    {
        private readonly IUserCharactersRepository _repository;
        private readonly ICharactersRepository _charactersRepository;
        private readonly IValidator<CreateUserCharacterCommand> _validator;
        private readonly ILogger<CreateUserCharacterHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCharacterHandler(
            IUserCharactersRepository repository,
            ICharactersRepository charactersRepository,
            IValidator<CreateUserCharacterCommand> validator,
            ILogger<CreateUserCharacterHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _charactersRepository = charactersRepository;
            _validator = validator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid, ErrorList>> Handle(CreateUserCharacterCommand command, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var characterResult = await _charactersRepository.GetById(command.CharacterId);

            if (!characterResult.IsSuccess)
                return characterResult.Error.ToErrorList();

            var character = characterResult.Value;


            var entity = UserCharacterEntity.Create(
                command.UserId,
                character
                );

            await _repository.Add(entity);

            await _unitOfWork.SaveChanges();

            return entity.Id;
        }
    }
}
