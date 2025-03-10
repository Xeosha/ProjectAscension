
using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Repositories;

namespace GameService.Data.Repositories
{
    public class ProffesionRepository : RepositoryCRUD<ProffesionEntity>, IProffesionsRepository
    {
        public ProffesionRepository(GameServiceDbContext dbContext) : base(dbContext) { }

    }
}
