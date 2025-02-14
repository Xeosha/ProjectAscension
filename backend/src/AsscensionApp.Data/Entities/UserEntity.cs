using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsscensionApp.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<TeamEntity> Team { get; set; } = new();
        public List<UserEntity> Users { get; set;} = new();
        public UserCharacterEntity Character { get; set; } = new();
        public InventoryEntity Inventory { get; set; } = new();
    }
}
