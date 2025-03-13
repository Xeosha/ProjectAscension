    using GameService.CORE.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GameService.CORE.Entities;

namespace GameService.Data.Configurations.Read
{
    public class ProffesionDtoConfiguration : IEntityTypeConfiguration<ProffesionDto>
    {
        public void Configure(EntityTypeBuilder<ProffesionDto> builder)
        {
        }
    }
}
