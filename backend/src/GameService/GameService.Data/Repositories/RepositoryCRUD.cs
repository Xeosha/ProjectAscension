using CSharpFunctionalExtensions;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GameService.Data.Repositories
{
    public abstract class RepositoryCRUD<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryCRUD(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async virtual Task<Result> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async virtual Task<Result<T, Error>> Delete(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                return Errors.General.NotFound(id);
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            var entities = await _dbSet.Where(predicate).ToListAsync();
            return entities;
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            var entities = await _dbSet.AsNoTracking().ToListAsync();
            return entities;
        }

        public async virtual Task<Result<T, Error>> GetById(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return Errors.General.NotFound(id);
            }

            return entity;
        }

        public async virtual Task<Result<T, Error>> Update(Guid id, T entity)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing == null)
            {
                return Errors.General.NotFound(id);
            }

            entity.Id = existing.Id;
            _context.Entry(existing).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
                
            return existing;
        }
    }
}
