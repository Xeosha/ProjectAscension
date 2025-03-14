using FluentValidation;

namespace GameService.Application.Commands.UserCharacter.Update
{
    public class UpdateUserCharacterCommandValidator : AbstractValidator<UpdateUserCharacterCommand>
    {
        public UpdateUserCharacterCommandValidator() { }
    }
}
