using System.Security.Cryptography;
using System.Text;
using Admin.Application.Mappings;
using Admin.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Admin.Infrustructure;

public static class DependecyInjection
{

    public static IServiceCollection AddServer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(HostMapper).Assembly);
        services.AddApplicationServices();
        services.AddRepositories();
        services.AddConnection();

        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnectionDevelopment"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });
        return services;
    }
    public static IServiceCollection AddIdentityContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UserDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnectionDevelopment"),
                m => m.MigrationsAssembly(typeof(UserDbContext).Assembly.FullName));
        });
        return services;
    }
    
}
