
using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Repositories;
using GameService.Data.DbContexts;

namespace GameService.Data.Repositories
{
    public class TeamsRepository : RepositoryBase<TeamEntity>, ITeamsRepository
    {
        public TeamsRepository(WriteDbContext dbContext) : base(dbContext) { }
    }
    
}
