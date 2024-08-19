using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories;
using ConnectionControl.Application.Interfaces;
using ConnectionControl.Application.Services;
using ConnectionsControl.ConnectionLibrary.Connections;
using ConnectionsControl.ConnectionLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionControl.Infrustructure;

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
        services.AddScoped<IConnectionSNMPService, ConnectionSNMPService>();

        // Repositories
        services.AddScoped<IHardwareRepository, HardwareRepository>();

        // Connections
        services.AddScoped<IDataConnection, DataConnection>();

        return services;
    }
}
