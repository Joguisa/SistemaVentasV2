using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace POS.Api.Extensions
{
    public static class SwaggerExtensions
    {
        // Esto es para generar la documentación de Swagger
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "SV API",
                Version = "v1",
                Description = "Sistema de Venta - API 2024",
                TermsOfService = new Uri("https://github.com/Joguisa"),
                Contact = new OpenApiContact
                {
                    Name = "Joguisa Tech S.A",
                    Email = "jntnglln@gmail.com",
                    Url = new Uri("https://www.linkedin.com/in/jonatangsala/"),
                },
                License = new OpenApiLicense
                {
                    Name = "Use under LICX",
                    Url = new Uri("https://co.creativecommons.net/tipos-de-licencias/")
                }
            };

            // vamos a validar la generación de este swagger
            services.AddSwaggerGen(c =>
            {
                openApi.Version = "v1";
                c.SwaggerDoc("v1", openApi);

                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Jwt Authentication",
                    Description = "Jwt Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securitySchema.Reference.Id, securitySchema);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securitySchema, new string[] { }}
                });
            });
            return services;
        }
    }
}
