using FluentValidation;

namespace GameService.Application.Commands.UserCharacter.Create
{
    public class CreateUserCharacterCommandValidator : AbstractValidator<CreateUserCharacterCommand>
    {
        public CreateUserCharacterCommandValidator() { }
    }
}
