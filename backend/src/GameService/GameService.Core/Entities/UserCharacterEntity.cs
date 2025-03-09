

namespace GameService.CORE.Entities
{
    public class UserCharacterEntity : BaseEntity
    {
        public Guid UserId { get; set; }

        
        public uint ExpPerLevel = 100;
          

        public uint Attack;
        public uint Defense;
        public uint Health;

        public uint Power => CalculatePower();


        private uint _exp;
        public uint Level = 1;
        public uint Exp
        {
            get => _exp;
            private set
            {
                if (value >= 0) _exp = value;
                CheckLevelUp(); // Проверка повышения уровня при изменении опыта
            }
        }
        public void AddExp(uint amount)
        {
            if (amount > 0) Exp += amount;
        }
        private void CheckLevelUp()
        {
            while (Exp >= Level * ExpPerLevel)
            {
                Exp -= Level * ExpPerLevel;
                Level++;
                OnLevelUp();
            }
        }

        private void OnLevelUp()
        {
            // Увеличиваем характеристики при повышении уровня
        }

        // --- Экипировка ---
        private List<InventoryClothingEntity> _clothings = new();
        public List<InventoryClothingEntity> Clothings
        {
            get => _clothings;
            set
            {
                _clothings = value;
                UpdateStats(); // Пересчет характеристик при изменении экипировки
            }
        }


        // --- Профессия ---
        private ProffesionEntity? _proffesion;
        public Guid? ProffesionId { get; private set; }
        public ProffesionEntity? Proffesion
        {
            get => _proffesion;
            set
            {
                _proffesion = value;
                ProffesionId = value?.Id;
                UpdateStats(); // Обновляем крит при смене профессии
            }
        }


        // --- Базовый персонаж ---
        private CharacterEntity? _character;
        public Guid CharacterId { get; init; } // Инициализируется один раз
        public CharacterEntity? Character
        {
            get => _character;
            init
            {
                _character = value;
                InitializeFromCharacter(); // Инициализация при создании
            }
        }

        private UserCharacterEntity()
        { 

        }

        public static UserCharacterEntity Create(CharacterEntity baseCharacter, Guid userId)
        {
            return new UserCharacterEntity
            {
                Character = baseCharacter,
                UserId = userId
            };
        }

        public void EquipClothing(InventoryClothingEntity clothing)
        {
            if (clothing != null && !Clothings.Contains(clothing))
            {
                Clothings.Add(clothing);
                UpdateStats();
            }
        }

        private void UpdateStats()
        {
            
        }

        private uint CalculatePower()
        {
            return Level * 10 + Attack + Defense;
        }

        private void InitializeFromCharacter()
        {
            if (Character == null) 
                return;

            Health = Character.BaseHealth;
            Attack = Character.BaseAttack;
            Defense = Character.BaseDefense;
        }

    }
}
