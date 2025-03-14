using GameService.Application.Commands.UserCharacter.Update;

namespace GameService.API.Contracts.UserCharacter
{
    public record UpdateUserCharacterRequest
    (
       uint Attack,
       uint Defense,
       uint Health,
       Guid ProffesionId
    )
    {
        public UpdateUserCharacterCommand ToCommand(Guid id)
            => new(id, ProffesionId, Attack, Defense, Health);
    }
}
