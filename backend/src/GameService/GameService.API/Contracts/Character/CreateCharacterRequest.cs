using GameService.Application.Commands.Characters.Create;
using GameService.CORE.Entities;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace GameService.API.Contracts.Character
{
    public record CreateCharacterRequest
    (
        string name,
        string biography,
        CharacterRarity rarity,
        uint age,
        uint minLevel,
        uint maxLevel,
        uint baseAttack,
        uint baseDefense,
        uint baseHealth
    )
    {
        public CreateCharacterCommand ToCommand() =>
            new(name, biography, rarity, age, minLevel, maxLevel, baseAttack, baseDefense, baseHealth);
    }


}
