

namespace GameService.CORE.Entities
{
    public class UserCharacterEntity : BaseEntity
    {     
        public uint Attack { get; set; }
        public uint Defense { get; set; }
        public uint Health { get; set; }

        public uint Level {  get; set; }
        
        private uint _exp;
        public uint Exp
        {
            get => _exp;
            private set
            {
                if (value >= 0) _exp = value;
                CheckLevelUp(); // Проверка повышения уровня при изменении опыта
            }
        }

        public uint Power => CalculatePower();
        public uint ExpPerLevel => CalculateExpPerLevel();

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

        // --- Игрок ---
        public Guid UserId { get; set; } // Инициализируется один раз
        public UserEntity? User { get; set; }

        // --- Тима ---
        public Guid? TeamId { get; set; } // Инициализируется один раз
        public TeamEntity? Team { get; set; }

        private UserCharacterEntity()
        { 

        }

        public static UserCharacterEntity Create(Guid userId, CharacterEntity baseCharacter)
        {
            return new UserCharacterEntity
            {
                Character = baseCharacter,
                UserId = userId
            };
        }

        private void UpdateStats()
        {
            
        }

        private uint CalculatePower()
        {
            return Level * 10 + Attack + Defense;
        }

        private uint CalculateExpPerLevel()
        {
            return Level * 10;
        }

        private void InitializeFromCharacter()
        {
            if (Character == null) 
                return;
        }

        public void JoinTeam(TeamEntity team)
        {
            Team = team;
            TeamId = team.Id;
        }

        public void UpdateProffesion(ProffesionEntity proffesion)
        {
            Proffesion = proffesion;
            ProffesionId = proffesion.Id;
        }

        public void UpdateTeam(TeamEntity team)
        {
            Team = team;
            TeamId = team.Id;
        }

        public void UpdateUser(UserEntity user)
        {
            User = user;
            UserId = user.Id;
        }


        public void LeaveTeam()
        {
            Team = null;
            TeamId = null;
        }

    }
}
