﻿using Admin.Application.Interfaces;
using Admin.Application.Services;
using Admin.Domain.Interfaces;
using Admin.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Admin.Infrustructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = typeof(IHostService).Assembly;
        foreach (var type in assembly.GetTypes().Where(t => t.Name.EndsWith("Service")))
        {
            if (type.IsClass && !type.IsAbstract)
            {
                var interfaceType = type.GetInterface($"I{type.Name}")!;

                    services.AddScoped(interfaceType, type);
            }
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
            if (type.IsClass && !type.IsAbstract)
            {
                var valueInterface = interfaceType.GetTypes()
                    .Where(t => t.Name == ("I" + type.Name) 
                    && t.Name.EndsWith("Repository") && !t.Name.EndsWith("BaseRepository"))
                    .FirstOrDefault()!;

                    services.AddScoped(valueInterface, type);
            }
        }

        return services;
    }
}
