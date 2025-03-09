using FluentValidation;

namespace GameService.Application.Commands.Characters.Update
{

    public class UpdateCharacterMainInfoCommandValidator : AbstractValidator<UpdateCharacterMainInfoCommand>
    {
        public UpdateCharacterMainInfoCommandValidator()
        {
        }

    }

}