using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Entities;
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

        public CreateCharacterHandler(
            ICharactersRepository charactersRepository,
            IValidator<CreateCharacterCommand> validator,
            ILogger<CreateCharacterHandler> logger )
        {
            _charactersRepository = charactersRepository;
            _validator = validator;
            _logger = logger;   
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

            _logger.LogInformation("Created character {name} with id {id}", entity.Name, entity.Id);

            return entity.Id;
        }
    }
}
