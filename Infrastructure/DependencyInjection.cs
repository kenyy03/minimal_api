using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Uow.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbPrimary")));

            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddUnitOfWorkFactory((uow, provider) =>
            {
                uow.RegisterUnitOfWork(UnitOfWorkType.DbPrimary, provider.GetRequiredService<AppDbContext>());
            });
            return services;
        }
    }
}
