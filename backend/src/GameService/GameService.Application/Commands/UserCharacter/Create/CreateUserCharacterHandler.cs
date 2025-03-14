﻿using CSharpFunctionalExtensions;
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
        private readonly IUsersRepository _userRepository;
        private readonly IValidator<CreateUserCharacterCommand> _validator;
        private readonly ILogger<CreateUserCharacterHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCharacterHandler(
            IUserCharactersRepository repository,
            ICharactersRepository charactersRepository,
            IUsersRepository usersRepository,
            IValidator<CreateUserCharacterCommand> validator,
            ILogger<CreateUserCharacterHandler> logger,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _charactersRepository = charactersRepository;
            _validator = validator;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userRepository = usersRepository;
        }

        public async Task<Result<Guid, ErrorList>> Handle(CreateUserCharacterCommand command, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid == false)
            {
                return validationResult.ToList();
            }

            var characterResult = await _charactersRepository.GetById(command.CharacterId);
            var userResult = await _userRepository.GetById(command.UserId);

            if (!characterResult.IsSuccess)
                return characterResult.Error.ToErrorList();

            if (!userResult.IsSuccess)
                return userResult.Error.ToErrorList();

            var character = characterResult.Value;
            var user = userResult.Value;


            var entity = UserCharacterEntity.Create(
                user,
                character,
                command.Attack,
                command.Defense,
                command.Health
                );

            await _repository.Add(entity);

            await _unitOfWork.SaveChanges();

            return entity.Id;
        }
    }
}

//{
//  "userId": "baa415d4-f79a-4a82-9be2-6a0ad9270062",
//  "characterId": "ff887fcb-0efb-4c73-b8b1-643b8c2a67d2",
//  "attack": 1,
//  "defense": 2,
//  "health": 3
//}
