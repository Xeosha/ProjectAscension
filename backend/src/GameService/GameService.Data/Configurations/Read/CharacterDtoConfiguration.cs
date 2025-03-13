using GameService.CORE.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace GameService.Data.Configurations.Read
{
    public class CharacterDtoConfiguration : IEntityTypeConfiguration<CharacterDto>
    {
        public void Configure(EntityTypeBuilder<CharacterDto> builder)
        {

        }
    }
}
