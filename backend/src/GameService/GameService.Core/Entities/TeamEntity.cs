
namespace GameService.CORE.Entities
{
    public class TeamEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }    
        public uint Power { get; set; }  
        public List<UserCharacterEntity> Characters { get; set; }

    }
}
