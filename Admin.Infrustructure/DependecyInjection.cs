using Admin.Application.Interfaces;
using Admin.Application.Services;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories;
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
        services.AddScoped<IHardwareService, HardwareService> ();
        services.AddScoped<ISnmpService, SnmpService>();


        // Repositories
        services.AddScoped<IHardwareRepository, HardwareRepository>();
        services.AddScoped<ISnmpRepository, SnmpRepository>();


        return services;
    }
}
