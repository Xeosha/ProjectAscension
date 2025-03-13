using FluentValidation;
using GameService.Application.Commands.UserCharacter.Delete;

namespace GameService.Application.Commands.UserCharacter.Update
{
    public class UpdateUserCharacterCommandValidator : AbstractValidator<UpdateUserCharacterCommand>
    {
        public UpdateUserCharacterCommandValidator() { }
    }
}
