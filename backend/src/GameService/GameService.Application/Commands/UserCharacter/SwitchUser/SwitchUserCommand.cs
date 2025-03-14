

using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.UserCharacter.SwitchUser
{
    public record SwitchUserCommand
    (
        Guid Id,
        Guid UserId
    ) : ICommand
    {
    }
}
