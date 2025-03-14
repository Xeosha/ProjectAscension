using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.UserCharacter.Update
{
    public record UpdateUserCharacterCommand(
       Guid Id,
       Guid ProffesionId,
       uint Attack,
       uint Defense,
       uint Health
    ) : ICommand;
}
