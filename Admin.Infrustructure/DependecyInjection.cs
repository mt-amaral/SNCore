using Admin.Application.Mappings;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Admin.Infrustructure;

public static class DependecyInjection
{

    public static IServiceCollection AddServer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(HostMapper).Assembly);
        services.AddApplicationServices();
        services.AddRepositories();

        return services;
    }

    public static IServiceCollection AddContextDevelopment(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnectionDevelopment"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });
        return services;
    }


    public static IServiceCollection AddContextProduction(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnectionProduction"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });
        return services;
    }

    public static IServiceCollection AddContextStaging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnectionStaging"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });
        return services;
    }
}
