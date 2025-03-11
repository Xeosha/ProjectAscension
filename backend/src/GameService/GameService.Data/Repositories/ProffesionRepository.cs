
using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Repositories;
using GameService.Data.DbContexts;

namespace GameService.Data.Repositories
{
    public class ProffesionRepository : RepositoryBase<ProffesionEntity>, IProffesionsRepository
    {
        public ProffesionRepository(WriteDbContext dbContext) : base(dbContext) { }

    }
}
