using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infrastructure.FileStorage;
using POS.Infrastructure.Persistences.Contexts;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Infrastructure.Persistences.Repositories;

namespace POS.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(DBSISTEMAVENTASContext).Assembly.FullName;

            services.AddDbContext<DBSISTEMAVENTASContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient
            );

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IAzureStorage, AzureStorage>();
            return services;
        }
    }
}
