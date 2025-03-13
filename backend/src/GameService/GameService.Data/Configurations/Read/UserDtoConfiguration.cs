
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GameService.CORE.DTO;


namespace GameService.Data.Configurations.Read
{
    public class UserDtoConfiguration : IEntityTypeConfiguration<UserDto>
    {
        public void Configure(EntityTypeBuilder<UserDto> builder)
        {
        }
    }
}
