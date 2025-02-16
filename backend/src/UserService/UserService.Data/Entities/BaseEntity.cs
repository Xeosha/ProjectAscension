
using System.ComponentModel.DataAnnotations;

namespace UserService.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
