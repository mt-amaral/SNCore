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

    public static IServiceCollection AddContextDevelopment(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnectionDevelopment"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });
        return services;
    }

    
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = configuration["Jwt:SecurityKey"] ?? throw new Exception("Chave JWT não configurada");
        var salt = Encoding.UTF8.GetBytes(configuration["Jwt:Salt"] ?? "default-salt-123");
    
        byte[] derivedKey = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(secretKey),
            salt,
            iterations: 100_000,
            HashAlgorithmName.SHA256,
            outputLength: 32
        );

        // 2. Configuração mínima do JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(derivedKey),
                
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        return services;
    }
    
}
