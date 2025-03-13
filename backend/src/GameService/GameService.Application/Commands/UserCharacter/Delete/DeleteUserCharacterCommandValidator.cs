using FluentValidation;

namespace GameService.Application.Commands.UserCharacter.Delete
{
    public class DeleteUserCharacterCommandValidator : AbstractValidator<DeleteUserCharacterCommand>
    {
        public DeleteUserCharacterCommandValidator() { }    
    }
}
