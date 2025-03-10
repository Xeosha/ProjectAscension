using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.Proffesions.Create
{
    public class CreateProffesionHandler : ICommandHandler<Guid, CreateProffesionCommand>
    {
        private readonly IProffesionsRepository _proffesionsRepository;
        private readonly IValidator<CreateProffesionCommand> _validator;
        private readonly ILogger<CreateProffesionHandler> _logger;

        public CreateProffesionHandler(
            IProffesionsRepository proffesionsRepository,
            IValidator<CreateProffesionCommand> validator,
            ILogger<CreateProffesionHandler> logger )
        {
            _proffesionsRepository = proffesionsRepository;
            _validator = validator;
            _logger = logger;   
        }

        public async Task<Result<Guid, ErrorList>> Handle(CreateProffesionCommand command, CancellationToken cancellationToken = default)
        {

            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var result = ProffesionEntity.Create(
                command.name);

            if (!result.IsSuccess)
                return Errors.General.AlreadyExist().ToErrorList();

            var entity = result.Value;

            await _proffesionsRepository.Add(entity);
           

            _logger.LogInformation("Created proffesion {name} with id {id}", entity.Name, entity.Id);

            return entity.Id;
        }
    }
}
