using GameService.CORE.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace GameService.Data.Configurations.Read
{
    public class TeamDtoConfiguration : IEntityTypeConfiguration<TeamDto>
    {
        public void Configure(EntityTypeBuilder<TeamDto> builder)
        {
            builder.ToTable("Teams"); // Используйте реальное имя таблицы
            builder.HasKey(u => u.Id);
        }
    }
}
