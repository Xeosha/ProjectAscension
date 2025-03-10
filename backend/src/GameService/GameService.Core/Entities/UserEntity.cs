
namespace GameService.CORE.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name {  get; set; }   
        public string Email { get; set; }
        public string UserName { get; set; }
        private UserEntity(string name, string email, string userName) 
        { 
            Name = name;
            Email = email;
            UserName = userName;
        }

        static public UserEntity Create(string name, string email, string userName) 
            => new UserEntity(name, email, userName);


        public List<TeamEntity> Teams { get; set; } = new();
        public List<CharacterEntity> Characters { get; set; } = new();
        public List<UserCharacterEntity> UserCharacters { get; set; } = new();

    }
}
