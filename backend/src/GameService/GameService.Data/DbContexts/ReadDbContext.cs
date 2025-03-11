using GameService.CORE.DTO;
using GameService.CORE.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data.DbContexts
{
    public class ReadDbContext : DbContext, IReadDbContext
    {

        public IQueryable<CharacterDto> Characters => Set<CharacterDto>();

        public IQueryable<TeamDto> Teams => Set<TeamDto>();

        public IQueryable<UserDto> Users => Set<UserDto>();

        public IQueryable<UserCharacterDto> UserCharacters => Set<UserCharacterDto>();

        public IQueryable<ProffesionDto> Proffesions => Set<ProffesionDto>();

        public ReadDbContext(DbContextOptions<ReadDbContext> options)
           : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(WriteDbContext).Assembly,
                type => type.FullName?.Contains("Configurations.Read") ?? false);
            
        }

    }
}
