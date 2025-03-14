using GameService.Application.Commands.UserCharacter.SwitchUser;

namespace GameService.API.Contracts.UserCharacter
{
    public record SwitchUserInCharacterRequest
    (
        Guid UserId
    )
    {
        public SwitchUserCommand ToCommand(Guid id)
            => new SwitchUserCommand(id, UserId);
    }
}
