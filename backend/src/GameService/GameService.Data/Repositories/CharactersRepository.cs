using CSharpFunctionalExtensions;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using GameService.CORE.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameService.Data.Repositories
{
    public class CharactersRepository : ICharactersRepository
    {
        GameServiceDbContext _dbContext;
        public CharactersRepository(GameServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Add(CharacterEntity character)
        {
            await _dbContext.Characters.AddAsync(character);
            await _dbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result<CharacterEntity, Error>> Delete(Guid id)
        {

            var character = await _dbContext.Characters.FindAsync(id);

            if (character == null)
            {
                return Errors.General.NotFound(id);
            }

            _dbContext.Characters.Remove(character);
            await _dbContext.SaveChangesAsync();
            return character;
        }

        public async Task<IEnumerable<CharacterEntity>> Find(Expression<Func<CharacterEntity, bool>> predicate)
        {
            var characters = await _dbContext.Characters.Where(predicate).ToListAsync();
            return characters;
        }

        public async Task<IEnumerable<CharacterEntity>> GetAll()
        {
            var characters = await _dbContext.Characters.ToListAsync();
            return characters;
        }

        public async Task<Result<CharacterEntity, Error>> GetById(Guid id)
        {  
            var character = await _dbContext.Characters.FindAsync(id);
            if (character == null)
            {
                return Errors.General.NotFound(id);
            }

            return character;
        }

        public async Task<Result<CharacterEntity, Error>> UpdateMainInfo(Guid id, string name, string biography, uint age)
        {
            var existing = await _dbContext.Characters.FindAsync(id);
            if (existing == null)
            {
                return Errors.General.NotFound(id);   
            }

            existing.Name = name;   
            existing.Biography = biography; 
            existing.Age = age; 

            _dbContext.Characters.Update(existing);

            await _dbContext.SaveChangesAsync();

            return existing;


        }
    }
}
