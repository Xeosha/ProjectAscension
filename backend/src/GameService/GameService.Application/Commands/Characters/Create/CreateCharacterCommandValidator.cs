
using FluentValidation;

namespace GameService.Application.Commands.Characters.Create
{
    public class CreateCharacterCommandValidator : AbstractValidator<CreateCharacterCommand>
    {
        public CreateCharacterCommandValidator()
        {
        }
    }
}
