


using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.UserCharacter.Create
{
    public record CreateUserCharacterCommand
    (
        Guid UserId,
        Guid CharacterId,
        uint Attack,
        uint Defense,
        uint Health
    ) : ICommand;
}
