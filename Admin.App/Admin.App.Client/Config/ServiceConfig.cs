
namespace Admin.App.Client.Config;

public static class ServiceConfig
{
    public static IServiceCollection AddServerWeb(this IServiceCollection services)
    {
        var assembly = typeof(ServiceConfig).Assembly;
        foreach (var type in assembly.GetTypes().Where(t => t.Name.EndsWith("Service")))
        {

            services.AddTransient(type);
        }

        return services;
    }
}