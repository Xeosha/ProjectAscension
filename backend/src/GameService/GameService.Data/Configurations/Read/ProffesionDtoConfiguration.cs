using GameService.CORE.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data.Configurations.Read
{
    public class ProffesionDtoConfiguration : IEntityTypeConfiguration<ProffesionDto>
    {
        public void Configure(EntityTypeBuilder<ProffesionDto> builder)
        {
            builder.ToTable("Proffesions");
            builder.HasKey(u => u.Id);
        }
    }
}
