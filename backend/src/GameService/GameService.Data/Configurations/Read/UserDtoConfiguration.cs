using GameService.CORE.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace GameService.Data.Configurations.Read
{
    public class UserDtoConfiguration : IEntityTypeConfiguration<UserDto>
    {
        public void Configure(EntityTypeBuilder<UserDto> builder)
        {
            builder.ToTable("Users"); // Используйте реальное имя таблицы
            builder.HasKey(u => u.Id);
        }
    }
}
