

namespace GameService.CORE.Entities
{
    public class ProffesionEntity : BaseEntity
    {
        List<UserCharacterEntity> UserCharacters = new();

        public string Name { get; set; } = "NoProffesion";
    }
}
