using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Abstractions;

namespace GameService.Application.Commands.Characters.Create
{
    public record CreateCharacterCommand
    (
        string name,
        string biography,
        CharacterRarity rarity,
        uint age,
        uint minLevel,
        uint maxLevel
    ) : ICommand;
}
