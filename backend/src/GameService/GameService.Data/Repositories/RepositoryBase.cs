using CSharpFunctionalExtensions;
using GameService.CORE.Common;
using GameService.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace GameService.Data.Repositories
{
    public abstract class RepositoryBase<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public Guid Save(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Attach(entity);
            return entity.Id;
        }

        public async virtual Task<Result> Add(T entity)
        {
            await _dbSet.AddAsync(entity);

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
            return entity;
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
                
            return existing;
        }
    }
}
