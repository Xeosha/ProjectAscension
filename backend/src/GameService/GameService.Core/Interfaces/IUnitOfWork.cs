

using System.Data;

namespace GameService.CORE.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<IDbTransaction> BeginTransaction(CancellationToken cancellationToken = default);

        public Task SaveChanges(CancellationToken cancellationToken = default);
    }
}
