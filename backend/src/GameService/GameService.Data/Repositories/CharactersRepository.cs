using CSharpFunctionalExtensions;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Repositories;
using GameService.Data.DbContexts;

namespace GameService.Data.Repositories
{
    public class CharactersRepository : RepositoryBase<CharacterEntity>, ICharactersRepository
    {
        public CharactersRepository(WriteDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Result<CharacterEntity, Error>> UpdateMainInfo(Guid id, string name, string biography, uint age)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing == null)
            {
                return Errors.General.NotFound(id);   
            }

            existing.Name = name;   
            existing.Biography = biography; 
            existing.Age = age; 

            _dbSet.Update(existing);

            await _context.SaveChangesAsync();

            return existing;


        }
    }
}
