using Admin.Persistence.Context;
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

        services.AddApplicationServices();

        services.AddRepositories();

        services.AddValidators();

        return services;
    }
}
