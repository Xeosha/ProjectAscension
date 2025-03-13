using GameService.Application.Commands.UserCharacter.Update;

namespace GameService.API.Contracts.UserCharacter
{
    public record UpdateUserCharacterRequest
    (
       uint Attack,
       uint Defense,
       uint Health,
       Guid UserId,
       Guid ProffesionId,
       Guid TeamId
    )
    {
        public UpdateUserCharacterCommand ToCommand(Guid id)
            => new(id, Attack, Defense, Health, UserId, ProffesionId, TeamId);
    }
}
