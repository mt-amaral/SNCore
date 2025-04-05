using Admin.Application.Interfaces;
using Admin.Connection.Connections;
using Admin.Connection.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Infrustructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = typeof(IHostService).Assembly;
        foreach (var type in assembly.GetTypes().Where(t => t.Name.EndsWith("Service")))
        {
            if (!type.IsClass || type.IsAbstract) continue;
            var interfaceType = type.GetInterface($"I{type.Name}")!;

            services.AddScoped(interfaceType, type);
        }
        return services;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {

        var repositoryType = typeof(HostRepository).Assembly;
        var interfaceType = typeof(IHostRepository).Assembly;

        var types = repositoryType.GetTypes()
            .Where(t => t.Name.EndsWith("Repository") && !t.Name.EndsWith("BaseRepository"));

        foreach (var type in types)
        {
            if (!type.IsClass || type.IsAbstract) continue;
            var valueInterface = interfaceType
                .GetTypes()
                .FirstOrDefault(t => t.Name == ("I" + type.Name)
                                     && t.Name.EndsWith("Repository") && !t.Name.EndsWith("BaseRepository"))!;
            services.AddScoped(valueInterface, type);
        }
        return services;
    }

    public static IServiceCollection AddConnection(this IServiceCollection service)
    {

        service.AddScoped<ISnmpConnection, SnmpConnection>();
        return service;
    }
}
