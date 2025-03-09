using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.Characters.Delete
{
    public class DeleteCharacterHandler : ICommandHandler<Guid, DeleteCharacterCommand>
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly IValidator<DeleteCharacterCommand> _validator;
        private readonly ILogger<DeleteCharacterHandler> _logger;

        public DeleteCharacterHandler(ICharactersRepository charactersRepository, IValidator<DeleteCharacterCommand> validator, ILogger<DeleteCharacterHandler> logger)
        {
            _charactersRepository = charactersRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result<Guid, ErrorList>> Handle(
        DeleteCharacterCommand command,
        CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var result = await _charactersRepository.Delete(command.CharacterId);

            if (result.IsFailure)
                return result.Error.ToErrorList();

            var character = result.Value;


            _logger.LogInformation("Updated deleted with id {character.Id}", character.Id);

            return character.Id;
        }

    }
}
