

using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.Characters.UpdateMainInfo
{

    public record UpdateCharacterMainInfoCommand
    (
        Guid characterId,
        string name,
        string biography,
        uint age
    ) : ICommand;
}
