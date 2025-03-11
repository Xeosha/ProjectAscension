using GameService.CORE.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data.Configurations.Read
{
    public class UserCharacterDtoConfiguration : IEntityTypeConfiguration<UserCharacterDto>
    {
        public void Configure(EntityTypeBuilder<UserCharacterDto> builder)
        {
            builder.ToTable("UsersCharacters"); // Используйте реальное имя таблицы
            builder.HasKey(u => u.Id);
        }
    }
}
