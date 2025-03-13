using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.Application.Commands.Proffesions.Delete;
using GameService.CORE.Common;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using GameService.CORE.Interfaces;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.Team.Delete
{
    public class DeleteTeamHandler : ICommandHandler<Guid, DeleteTeamCommand>
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IValidator<DeleteTeamCommand> _validator;
        private readonly ILogger<DeleteProffesionHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeamHandler(
            ITeamsRepository teamsRepository,
            IValidator<DeleteTeamCommand> validator,
            ILogger<DeleteProffesionHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _teamsRepository = teamsRepository;
            _validator = validator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid, ErrorList>> Handle(
        DeleteTeamCommand command,
        CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var result = await _teamsRepository.Delete(command.TeamId);

            if (result.IsFailure)
                return result.Error.ToErrorList();

            await _unitOfWork.SaveChanges();

            var proffesion = result.Value;

            _logger.LogInformation("Deleted proffesion with id {proffesion.Id}", proffesion.Id);

            return proffesion.Id;
        }

    }
}
