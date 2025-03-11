using GameService.CORE.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data.Configurations.Write
{
    public class ProffesionConfiguration
    : IEntityTypeConfiguration<ProffesionEntity>
    {
        public void Configure(EntityTypeBuilder<ProffesionEntity> builder)
        {
            builder.ToTable("Proffesions");

            builder.HasMany(p => p.UserCharacters)
               .WithOne() // Если есть обратная навигация в UserCharacterEntity, укажите ее
               .HasForeignKey(uc => uc.ProffesionId) // Укажите имя свойства внешнего ключа
               .OnDelete(DeleteBehavior.Restrict); // Или другой подходящий DeleteBehavior


        }
    }
}
