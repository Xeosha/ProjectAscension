using GameService.CORE.Entities;

namespace GameService.API.Contracts.Character
{
    public class CharacterResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public uint Age { get; set; }
        public CharacterRarity Rarity { get; set; }
        public uint MinLevel { get; set; }
        public uint MaxLevel { get; set; }
        public uint BaseAttack { get; set; }
        public uint BaseDefense { get; set; }
        public uint BaseHealth { get; set; }

    }
}
