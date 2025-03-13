
using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.User.Delete
{
    public record DeleteUserCommand(Guid UserId) : ICommand;
}
