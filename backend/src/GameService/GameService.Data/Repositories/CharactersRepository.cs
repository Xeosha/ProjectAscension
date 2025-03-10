using CSharpFunctionalExtensions;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Repositories;

namespace GameService.Data.Repositories
{
    public class CharactersRepository : RepositoryCRUD<CharacterEntity>, ICharactersRepository
    {
        public CharactersRepository(GameServiceDbContext dbContext) : base(dbContext)
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
