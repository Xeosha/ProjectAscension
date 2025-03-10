

using CSharpFunctionalExtensions;
using GameService.CORE.Common;

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

        public uint BaseAttack = 1;
        public uint BaseDefense = 1;
        public uint BaseHealth = 1;

        public List<UserEntity> Users { get; set; } = new();
        public List<UserCharacterEntity> UserCharacters { get; set; } = new();

        private CharacterEntity() : base()
        {

        }

        public static Result<CharacterEntity, Error> Create(
            string name, string biography, CharacterRarity rarity,
            uint age, uint minLevel, uint maxLevel,
            uint baseAttack, uint baseDefense, uint baseHealth) 
        {
            var entity = new CharacterEntity
            {
                Name = name,
                Biography = biography,
                Rarity = rarity,
                Age = age,
                MinLevel = minLevel,
                MaxLevel = maxLevel,
                BaseAttack = baseAttack,
                BaseDefense = baseDefense,
                BaseHealth = baseHealth
            };

            return entity;
        }
    }
}
