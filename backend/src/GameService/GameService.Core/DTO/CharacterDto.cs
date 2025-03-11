using GameService.CORE.Entities;

namespace GameService.CORE.DTO
{
    public record CharacterDto(
        Guid Id,
        string Name,
        string Biography,
        uint Age,
        CharacterRarity Rarity,
        uint MinLevel,
        uint MaxLevel
    );
    
}

