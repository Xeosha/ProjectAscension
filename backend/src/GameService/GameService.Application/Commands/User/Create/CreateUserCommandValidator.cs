using FluentValidation;

namespace GameService.Application.Commands.User.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {

        }
    }
}
