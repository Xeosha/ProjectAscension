using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.Proffesions.Update
{
    public class UpdateProffesionHandler : ICommandHandler<Guid, UpdateProffesionCommand>
    {
        private readonly IProffesionsRepository _proffesionsRepository;
        private readonly IValidator<UpdateProffesionCommand> _validator;
        private readonly ILogger<UpdateProffesionHandler> _logger;

        public UpdateProffesionHandler(
            IProffesionsRepository proffesionsRepository,
            IValidator<UpdateProffesionCommand> validator,
            ILogger<UpdateProffesionHandler> logger)
        {
            _proffesionsRepository = proffesionsRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result<Guid, ErrorList>> Handle(UpdateProffesionCommand command, CancellationToken cancellationToken = default)
        {

            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var updateEntity = ProffesionEntity.Create(command.Name);

            if (!updateEntity.IsSuccess)
            {
                return updateEntity.Error.ToErrorList();
            }

            _logger.LogInformation("Find proffesion {name} with id {id}", command.Name, command.ProffesionId);

            var result = await _proffesionsRepository.Update(command.ProffesionId, updateEntity.Value);

            if (!result.IsSuccess)
                return result.Error.ToErrorList();

            var entity = result.Value;

            _logger.LogInformation("Updated proffesion {name} with id {id}", entity.Name, entity.Id);

            return entity.Id;
        }
    }
}
