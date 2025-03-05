

namespace GameService.CORE.Entities
{
    public class CharacterEntity : BaseEntity
    {
        private uint minLelel;
        private uint maxLelel;

        public string Name { get; set; } = "NoName";
        public string Biography { get; set; } = string.Empty;
        public uint Age { get; set; } = 18;
        public CharacterRarity Rarity { get; set; }
        public uint MinLevel {
            get => minLelel;
            set
            {
                if (value > 0 && value < maxLelel)
                    minLelel = value;
            }
        }
        public uint MaxLevel
        {
            get => maxLelel;
            set
            {
                if (value > 0 && value > minLelel)
                    maxLelel = value;
            }
        }
    }
}
