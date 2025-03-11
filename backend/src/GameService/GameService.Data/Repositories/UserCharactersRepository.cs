using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Repositories;
using GameService.Data.DbContexts;


namespace GameService.Data.Repositories
{
    public class UserCharactersRepository : RepositoryBase<UserCharacterEntity>, IUserCharactersRepository
    {
        public UserCharactersRepository(WriteDbContext dbContext) : base(dbContext) { }
    }
}
