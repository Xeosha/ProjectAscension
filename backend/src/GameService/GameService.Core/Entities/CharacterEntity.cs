

using CSharpFunctionalExtensions;
using GameService.CORE.Common;

namespace GameService.CORE.Entities
{
    public class CharacterEntity : BaseEntity
    {
        public string Name { get; set; } = "NoName";
        public string Biography { get; set; } = string.Empty;
        public uint Age { get; set; } = 18;
        public CharacterRarity Rarity { get; set; } = 0;
        public uint MinLevel { get; set; } = 1;
        public uint MaxLevel { get; set; } = 100;

        public List<UserEntity> Users { get; set; } = new();
        public List<UserCharacterEntity> UserCharacters { get; set; } = new();

        private CharacterEntity() : base()
        {

        }

        public static Result<CharacterEntity, Error> Create(
            string name, string biography, CharacterRarity rarity,
            uint age, uint minLevel, uint maxLevel) 
        {
            var entity = new CharacterEntity
            {
                Name = name,
                Biography = biography,
                Rarity = rarity,
                Age = age,
                MinLevel = minLevel,
                MaxLevel = maxLevel,
            };

            return entity;
        }
    }
}
