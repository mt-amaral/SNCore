
using Admin.App.Client.Service;
using Admin.Shared.Interfaces;

namespace Admin.App.Client.Config;

public static class ServiceConfig
{
    public static IServiceCollection AddServerWeb(this IServiceCollection services)
    {
        var serviceType = typeof(HostService).Assembly;
        var interfaceType = typeof(IHostService).Assembly;

        var types = serviceType.GetTypes()
            .Where(t => t.Name.EndsWith("Service"));

        foreach (var type in types)
        {
            if (!type.IsClass || type.IsAbstract) continue;
            var valueInterface = interfaceType
                .GetTypes()
                .FirstOrDefault(t => t.Name == ("I" + type.Name)
                                     && t.Name.EndsWith("Service"))!;

            services.AddTransient(valueInterface, type);
        }
        return services;
    }
}