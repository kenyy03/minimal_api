using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Uow.Extensions
{
    public static class RegisterUnitOfWork
    {
        public static void AddUnitOfWorkFactory(this IServiceCollection services, Action<IUnitOfWorkFactory, IServiceProvider> configure)
        {
            services.AddScoped((Func<IServiceProvider, IUnitOfWorkFactory>)delegate (IServiceProvider resolver)
            {
                UnitOfWorkFactory unitOfWorkFactory = new();
                configure(unitOfWorkFactory, resolver);
                return unitOfWorkFactory;
            });
        }
    }
}
