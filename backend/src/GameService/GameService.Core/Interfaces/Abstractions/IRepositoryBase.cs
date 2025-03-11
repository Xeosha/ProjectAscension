

using CSharpFunctionalExtensions;
using GameService.CORE.Common;
using System.Linq.Expressions;

namespace GameService.CORE.Interfaces.Abstractions
{
    public interface IRepositoryBase<T>
    {
        Task<Result<T, Error>> GetById(Guid id);
        Task<Result> Add(T entity);
        Task<Result<T, Error>> Update(Guid id, T entity);
        Task<Result<T, Error>> Delete(Guid id);
    }
}
