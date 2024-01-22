using POS.Api.Extensions;
using POS.Application.Extensions;
using POS.Infrastructure.Extensions;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
var Cors = "Cors";

builder.Services.AddInjectionInfrastructure(Configuration);
builder.Services.AddInjectionApplication(Configuration);
builder.Services.AddAuthentication(Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors(Cors);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWatchDogExceptionLogger();

app.UseHttpsRedirection();

// haremos uso de un middleware para poder hacer la autenticación correctamente
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseWatchDog(configuration => {
    configuration.WatchPageUsername = Configuration.GetSection("WatchDog:Username").Value;
    configuration.WatchPagePassword = Configuration.GetSection("WatchDog:Password").Value;
});

app.Run();

public partial class Program { }