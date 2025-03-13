using FluentValidation;


namespace GameService.Application.Commands.User.Delete
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(d => d.UserId).NotEmpty();
        }
    }
}
