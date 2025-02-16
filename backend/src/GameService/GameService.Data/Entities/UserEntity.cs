using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public Guid UserId { get; set; } = new Guid();
        public List<TeamEntity> Team { get; set; } = new();
        public List<CharacterEntity> Characters { get; set;} = new();
        public UserCharacterEntity UserCharacter { get; set; } = new();
        public InventoryEntity Inventory { get; set; } = new();
    }
}
