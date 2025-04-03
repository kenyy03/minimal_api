using Domain.Abstractions;
using System.Data.Common;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        void Save();
        Task SaveAsync();
        void Commit();
        Task CommitAsync();
        void RollBack();
        Task RollBackAsync();
        void BeginTransaction();
        Task BeginTransactionAsync();
        List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map, int timeOut = 30, params object[] parameters) where T : class;
        void SetCommandTimeout(int seconds);
    }
}
