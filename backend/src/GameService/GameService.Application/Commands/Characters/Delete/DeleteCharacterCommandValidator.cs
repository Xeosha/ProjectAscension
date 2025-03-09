using FluentValidation;


namespace GameService.Application.Commands.Characters.Delete
{
    public class DeleteCharacterCommandValidator : AbstractValidator<DeleteCharacterCommand>
    {
        public DeleteCharacterCommandValidator()
        {
            RuleFor(d => d.CharacterId).NotEmpty();
        }
    }
}
