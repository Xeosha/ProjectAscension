

namespace GameService.CORE.Entities
{
    public class ClothingEntity : BaseEntity
    {
        public string Name { get; set; }    
        public ClothingType Type { get; set; }
        public uint BonusDamage { get; set; }
        public uint BonusDefense { get; set; }
        public List<InventoryClothingEntity> InventoryClothings { get; set; } = new();
        public List<InventoryEntity> Inventories { get;set; } = new();  
    }
}
