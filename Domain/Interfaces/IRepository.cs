using Domain.Abstractions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> AsQueryable();
        Task<T?> FindByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(params T[] entities);
        Task Delete(int id);
        void Update(T entity);
        void RemoveRange(params T[] entities);
    }
}
