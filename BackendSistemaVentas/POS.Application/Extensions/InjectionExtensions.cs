using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces;
using POS.Application.Services;
using System.Reflection;

namespace POS.Application.Extensions
{
    public static class InjectionExtensions
    {
        // registrar esta clase en el program
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSingleton(configuration);

            // De esta manera estamos inyectando todos los servicios que se encuentran en la capa de infraestructura
            // a nivel global
            //  Obsoleto
            //services.AddFluentValidation(options =>
            //{
            //    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            //});
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // registrar un ciclo de vida scoped
            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IProviderApplication, ProviderApplication>();

            return services;
        }

    }
}
