using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GameService.CORE.Entities;

namespace GameService.Data.Configurations
{
    public class InventoryClothingConfiguration : IEntityTypeConfiguration<InventoryClothingEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryClothingEntity> builder)
        {
            builder.ToTable("InventoryClothings");

        }
    }
}
