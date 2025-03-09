using GameService.CORE.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data.Configurations
{
    public class ProffesionConfiguration
    : IEntityTypeConfiguration<ProffesionEntity>
    {
        public void Configure(EntityTypeBuilder<ProffesionEntity> builder)
        {
            builder.ToTable("Proffesion");
        }
    }
}
