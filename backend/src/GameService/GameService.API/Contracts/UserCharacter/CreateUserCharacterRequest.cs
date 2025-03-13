using GameService.Application.Commands.UserCharacter.Create;

namespace GameService.API.Contracts.UserCharacter
{
    public record CreateUserCharacterRequest
    (
       Guid UserId,
       Guid CharacterId,
       uint Attack,
       uint Defense,
       uint Health
     )
    {
        public CreateUserCharacterCommand ToCommand()
            => new(UserId, CharacterId, Attack, Defense, Health);
    }
}
