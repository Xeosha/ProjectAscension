using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Repositories;
using GameService.Data.DbContexts;

namespace GameService.Data.Repositories
{
    public class UsersRepository : RepositoryBase<UserEntity>, IUsersRepository
    {
        public UsersRepository(WriteDbContext dbContext) : base(dbContext) { }
    }
}
