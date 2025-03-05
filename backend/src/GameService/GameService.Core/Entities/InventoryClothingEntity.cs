

namespace GameService.CORE.Entities
{
    public class InventoryClothingEntity : BaseEntity
    {
        public Guid InventoryId { get; set; }
        public InventoryEntity? Inventory {  get; set; }
                
        public Guid ClothingId { get; set; }
        public ClothingEntity? Clothing { get; set; }

        public Guid UserCharacterId { get; set; }
        public UserCharacterEntity? UserCharacter { get; set; }

    }
}
