using FluentValidation;

namespace GameService.Application.Commands.UserCharacter.SwitchUser
{
    public class SwitchUserCommandValidator : AbstractValidator<SwitchUserCommand>
    {
        public SwitchUserCommandValidator() { }
    }
}
