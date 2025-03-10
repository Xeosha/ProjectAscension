using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.Characters.UpdateMainInfo
{
    public class UpdateCharacterMainInfoHandler : ICommandHandler<Guid, UpdateCharacterMainInfoCommand>
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly IValidator<UpdateCharacterMainInfoCommand> _validator;
        private readonly ILogger<UpdateCharacterMainInfoHandler> _logger;

        public UpdateCharacterMainInfoHandler(
            ICharactersRepository charactersRepository,
            IValidator<UpdateCharacterMainInfoCommand> validator,
            ILogger<UpdateCharacterMainInfoHandler> logger)
        {
            _charactersRepository = charactersRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result<Guid, ErrorList>> Handle(UpdateCharacterMainInfoCommand command, CancellationToken cancellationToken = default)
        {

            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            _logger.LogInformation("Find character {name} with id {id}", command.name, command.characterId);
            var result = await _charactersRepository.UpdateMainInfo(command.characterId, command.name, command.biography, command.age);


            if (!result.IsSuccess)
                return result.Error.ToErrorList();

            var entity = result.Value;

            _logger.LogInformation("Updated character {name} with id {id}", entity.Name, entity.Id);

            return entity.Id;
        }
    }
}
