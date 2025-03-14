﻿using CSharpFunctionalExtensions;
using FluentValidation;
using GameService.CORE.Common;
using GameService.CORE.Interfaces;
using GameService.CORE.Interfaces.Abstractions;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GameService.Application.Commands.Proffesions.Delete
{
    public class DeleteProffesionHandler : ICommandHandler<Guid, DeleteProffesionCommand>
    {
        private readonly IProffesionsRepository _proffesionsRepository;
        private readonly IValidator<DeleteProffesionCommand> _validator;
        private readonly ILogger<DeleteProffesionHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProffesionHandler(
            IProffesionsRepository proffesionsRepository, 
            IValidator<DeleteProffesionCommand> validator, 
            ILogger<DeleteProffesionHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _proffesionsRepository = proffesionsRepository;
            _validator = validator;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid, ErrorList>> Handle(
        DeleteProffesionCommand command,
        CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var result = await _proffesionsRepository.Delete(command.ProffesionId);

            if (result.IsFailure)
                return result.Error.ToErrorList();

            await _unitOfWork.SaveChanges();

            var proffesion = result.Value;

            _logger.LogInformation("Updated deleted with id {character.Id}", proffesion.Id);

            return proffesion.Id;
        }

    }
}
