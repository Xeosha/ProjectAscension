
namespace GameService.CORE.Entities
{
    public class TeamEntity : BaseEntity
    {  
        public string Name { get; set; }
        public uint Power => CalculatePower();
        public List<UserCharacterEntity> Characters { get; set; } = new();

        public Guid UserId { get; set; }
        public UserEntity? user { get; set; }

        private uint CalculatePower()
        {
            return (uint)Characters.Sum(c => c.Power);
        }

    }
}
