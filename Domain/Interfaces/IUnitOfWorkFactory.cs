using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        void RegisterUnitOfWork<TDbContext>(UnitOfWorkType unitOfWorkType, TDbContext context);
        IUnitOfWork CreateUnitOfWork(UnitOfWorkType unitOfWorkType);
    }
}
