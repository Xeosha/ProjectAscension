using FluentValidation;


namespace GameService.Application.Commands.Proffesions.Delete
{
    public class DeleteProffesionCommandValidator : AbstractValidator<DeleteProffesionCommand>
    {
        public DeleteProffesionCommandValidator()
        {
            RuleFor(d => d.ProffesionId).NotEmpty();
        }
    }
}
