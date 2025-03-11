using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.Characters.Create
{
    public class CreateCharacterHandler : ICommandHandler<Guid, CreateCharacterCommand>
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly IValidator<CreateCharacterCommand> _validator;
        private readonly ILogger<CreateCharacterHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCharacterHandler(
            ICharactersRepository charactersRepository,
            IValidator<CreateCharacterCommand> validator,
            ILogger<CreateCharacterHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _charactersRepository = charactersRepository;
            _validator = validator;
            _logger = logger;   
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid, ErrorList>> Handle(CreateCharacterCommand command, CancellationToken cancellationToken = default)
        {

            var result = CharacterEntity.Create(
                command.name, command.biography, command.rarity, 
                command.age, command.minLevel, command.maxLevel, 
                command.baseAttack, command.baseHealth, command.baseDefense);

            if (!result.IsSuccess)
                return Errors.General.AlreadyExist().ToErrorList();

            var entity = result.Value;

            await _charactersRepository.Add(entity);

            await _unitOfWork.SaveChanges();

            _logger.LogInformation("Created character {name} with id {id}", entity.Name, entity.Id);

            return entity.Id;
        }
    }
}
