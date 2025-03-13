using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.UserCharacter.Update
{
    public record UpdateUserCharacterCommand(
       Guid Id,
       uint Attack,
       uint Defense,
       uint Health,
       Guid UserId,
       Guid ProffesionId,
       Guid TeamId
    ) : ICommand;
}
