﻿using Admin.Application.Scheduling;
using Admin.Application.Services;
using Admin.Connection.Connections;
using Admin.Connection.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Persistence.Repositories;
using Admin.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Admin.Infrustructure;
public static class ServiceCollectionExtensions
{
    
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
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

            services.AddScoped(valueInterface, type);
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

    public static IServiceCollection AddSchedules(this IServiceCollection service)
    {
        service.AddSingleton<ISchedulerFactory, Quartz.Impl.StdSchedulerFactory>();
        service.AddSingleton<ScopedJobFactory>();
        service.AddSingleton<RuntimeJob>();
        service.AddSingleton<JobScheduler>();
        service.AddHostedService(sp => sp.GetRequiredService<JobScheduler>());
        return service;
    }
    
    public static IServiceCollection AddConnection(this IServiceCollection service)
    {
        service.AddSingleton<ISnmpConnection, SnmpConnection>();
        return service;
    }

    public static IServiceCollection AddMetrics(this IServiceCollection service, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Timescale") !;
        service.AddScoped<IMonitoringScale>(options =>  new MonitoringScale(connectionString));
        
        return service;
    }
}
