using GameService.Application.Commands.User.Update;

namespace GameService.API.Contracts.User
{
    public record UpdateUserMainInfoRequest
    (
        string Name,
        string UserName,
        string Email
    )
    {
        public UpdateUserMainInfoCommand ToCommand(Guid id)
            => new(id, Name, UserName, Email);
    }
}


