

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

        public Guid? ProffesionId { get; set; }
        public ProffesionEntity? Proffesion { get; set; }


        public Guid CharacterId { get; set; }
        public CharacterEntity Character { get; set; }
       

        // --- Игрок ---
        public Guid UserId { get; set; } 
        public UserEntity? User { get; set; }

        // --- Тима ---
        public Guid? TeamId { get; set; } 
        public TeamEntity? Team { get; set; }


        private UserCharacterEntity(Guid userId, Guid characterId)
        {
            UserId = userId;
            CharacterId = characterId;
        }

        private UserCharacterEntity(UserEntity user, CharacterEntity baseCharacter, uint attack, uint defense, uint health)
        {
            Character = baseCharacter;
            User = user;
            UserId = user.Id;
            CharacterId = Character.Id;
            Attack = attack;
            Defense = defense;
            Health = Health;
        }

        public static UserCharacterEntity Create(UserEntity user, CharacterEntity baseCharacter, uint attack, uint defense, uint health)
            => new UserCharacterEntity(user, baseCharacter, attack, defense, health);

        public void UpdateStats(uint attack, uint defense, uint health)
        {
            Attack = attack;
            Defense = defense;
            Health = health;
        }

        private uint CalculatePower()
        {
            return Level * 10 + Attack + Defense + Health;
        }

        private uint CalculateExpPerLevel()
        {
            return Level * 10;
        }

        

        public void UpdateProffesion(ProffesionEntity proffesion)
        {
            Proffesion = proffesion;
            ProffesionId = proffesion.Id;
        }

        public void SwitchUser(UserEntity user)
        {
            LeaveTeam();

            User = user;
            UserId = user.Id;  
        }

        public void JoinTeam(TeamEntity team)
        {
            Team = team;
            TeamId = team.Id;

            team.Characters.Add(this);
        }

        public void LeaveTeam()
        {
            if (Team == null) 
                return;

            var currentTeam = Team;
            Team = null;
            TeamId = null;
            currentTeam.RemoveCharacter(this);

        }

    }
}
