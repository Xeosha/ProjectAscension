using System.ComponentModel.DataAnnotations;

namespace AsscensionApp.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
