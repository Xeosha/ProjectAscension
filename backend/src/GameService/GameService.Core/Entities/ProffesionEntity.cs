

using CSharpFunctionalExtensions;
using GameService.CORE.Common;

namespace GameService.CORE.Entities
{
    public class ProffesionEntity : BaseEntity
    {
        public List<UserCharacterEntity> UserCharacters { get; set; } = new();
        public string Name { get; set; } = "NoProffesion";

        private ProffesionEntity(string name) : base()
        {
            Name = name;
        }


        public static Result<ProffesionEntity, Error> Create(string name)
            => new ProffesionEntity(name);
    }
}
