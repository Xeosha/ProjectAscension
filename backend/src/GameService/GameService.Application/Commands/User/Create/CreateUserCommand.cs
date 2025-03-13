

using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.User.Create
{
    public record CreateUserCommand(
       string Name,
       string UserName,
       string Email
    ) : ICommand;
}
