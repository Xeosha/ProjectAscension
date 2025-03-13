using GameService.CORE.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace GameService.Data.Configurations.Read
{
    public class TeamDtoConfiguration : IEntityTypeConfiguration<TeamDto>
    {
        public void Configure(EntityTypeBuilder<TeamDto> builder)
        {

        }
    }
}
