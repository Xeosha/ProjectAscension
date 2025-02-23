using System.ComponentModel.DataAnnotations;

namespace GameService.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
