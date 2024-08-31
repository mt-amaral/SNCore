using Admin.Application.Interfaces;
using Admin.Application.Services;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories;
using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Validator.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Admin.Infrustructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnectionDev"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });
        // Services
        services.AddScoped<IHardwareService, HardwareService>();
        services.AddScoped<ISnmpService, SnmpService>();
        services.AddScoped<ITelnetService, TelnetService>();


        // Repositories
        services.AddScoped<IHardwareRepository, HardwareRepository>();
        services.AddScoped<ISnmpRepository, SnmpRepository>();
        services.AddScoped<ITelnetRepository, TelnetRepository>();

        // Validation
        services.AddScoped<IValidator<HardwareRequest>, HardwareValidation<HardwareRequest>>();
        services.AddScoped<IValidator<HardwarePayload>, HardwareValidation<HardwarePayload>>();

        services.AddScoped<IValidator<SnmpRequest>, SnmpValidation<SnmpRequest>>();
        services.AddScoped<IValidator<SnmpPayload>, SnmpValidation<SnmpPayload>>();

        services.AddScoped<IValidator<TelnetRequest>, TelnetValidation<TelnetRequest>>();
        services.AddScoped<IValidator<TelnetPayload>, TelnetValidation<TelnetPayload>>();

        return services;
    }
}
