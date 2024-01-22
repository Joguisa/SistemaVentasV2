using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WatchDog.src.Enums;
using WatchDog;

namespace POS.Application.Extensions.WatchDog
{
    public static class WatchDogExtensions
    {
        public static IServiceCollection AddWatchDog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWatchDogServices(options =>
            {
                options.SetExternalDbConnString = configuration.GetConnectionString("cadenaSQL");
                options.DbDriverOption = WatchDogDbDriverEnum.MSSQL;

                options.IsAutoClear = true;
                options.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Daily;
            });
            return services;
        }
    }
}

