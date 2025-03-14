using GameService.Application.Commands.Characters.Create;
using GameService.CORE.Entities;

namespace GameService.API.Contracts.Character
{
    public record CreateCharacterRequest
    (
        string name,
        string biography,
        CharacterRarity rarity,
        uint age,
        uint minLevel,
        uint maxLevel
    )
    {
        public CreateCharacterCommand ToCommand() =>
            new(name, biography, rarity, age, minLevel, maxLevel);
    }


}
