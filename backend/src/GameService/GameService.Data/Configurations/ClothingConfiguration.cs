
using GameService.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameService.Data.Configurations
{
    public class ClothingConfiguration : IEntityTypeConfiguration<ClothingEntity>
    {
        public void Configure(EntityTypeBuilder<ClothingEntity> builder)
        {
            builder.ToTable("Clothings");
        }
    }
}
