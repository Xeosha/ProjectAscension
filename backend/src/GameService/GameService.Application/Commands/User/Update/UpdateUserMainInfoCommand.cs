using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.User.Update
{

    public record UpdateUserMainInfoCommand(
       Guid Id,
       string Name,
       string UserName,
       string Email
    ) : ICommand;
}
