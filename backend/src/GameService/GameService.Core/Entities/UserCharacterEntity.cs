

namespace GameService.CORE.Entities
{
    public class UserCharacterEntity : BaseEntity
    {
        public Guid UserId { get; set; }

        public uint Exp = 0;
        public uint ExpPerLevel = 100;
        public uint Level = 1;
        public uint Power;

        public uint Attack;
        public uint Defense;
        public uint Health;
        public uint CritRate;
        public float CritPercentage = 0.01f;

        // Одежда
        public List<InventoryClothingEntity> Clothings { get; set; } = new();

        // Профессия
        public Guid ProffesionId { get; set; } 
        public CharacterProffesionEntity? Proffesion { get; set; } = new();
        
        // Базовый персонаж
        public Guid CharacterId { get; set; }
        public CharacterEntity? Character { get; set; } = new();

        private UserCharacterEntity()
        { 

        }

        public UserCharacterEntity Create()
        {
            return new UserCharacterEntity();
        }
    }
}
