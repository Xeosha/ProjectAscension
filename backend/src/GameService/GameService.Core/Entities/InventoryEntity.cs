

namespace GameService.CORE.Entities
{
    public class InventoryEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public uint Size { get; set; } = 50;
        public List<InventoryClothingEntity> InventoryClothings { get; set; } = new();
        public List<ClothingEntity> Clothings { get; set; } = new();    
        
    }
}
