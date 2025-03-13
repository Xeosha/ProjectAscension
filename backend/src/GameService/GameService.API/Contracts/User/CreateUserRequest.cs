
using GameService.Application.Commands.User.Create;

namespace GameService.API.Contracts.User
{
    public record CreateUserRequest
    (
        string Name,
        string UserName,
        string Email
    )
    {
        public CreateUserCommand ToCommand()
            => new(Name, UserName, Email);
    }
}
