

using CSharpFunctionalExtensions;
using GameService.CORE.Common;
using System.Linq.Expressions;

namespace GameService.CORE.Interfaces.Abstractions
{
    public interface IRepositoryCRUD<T>
    {
        Task<Result<T, Error>> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<Result> Add(T entity);
        Task<Result<T, Error>> Update(Guid id, T entity);
        Task<Result<T, Error>> Delete(Guid id);
    }
}
