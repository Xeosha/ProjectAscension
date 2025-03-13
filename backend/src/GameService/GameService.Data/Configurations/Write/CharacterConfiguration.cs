using GameService.CORE.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data.Configurations.Write
{
    public class CharacterConfiguration : IEntityTypeConfiguration<CharacterEntity>
    {
        public void Configure(EntityTypeBuilder<CharacterEntity> builder)
        {
            builder.ToTable("Characters");

            builder.HasMany(i => i.UserCharacters)
                .WithOne()
                .HasForeignKey(i => i.CharacterId);


        }
    }
}
