using Admin.Application.Interfaces;
using Admin.Application.Services;
using Admin.Domain.Interfaces;
using Admin.Persistence.Repositories;
using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Validator.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Infrustructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IHostService, HostService>();
        services.AddScoped<ISnmpService, SnmpService>();
        services.AddScoped<ITelnetService, TelnetService>();
        services.AddScoped<IHostGroupService, HostGroupService>();
        services.AddScoped<IHostModelService, HostModelService>();

        return services;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IHostRepository, HostRepository>();
        services.AddScoped<ISnmpRepository, SnmpRepository>();
        services.AddScoped<ITelnetRepository, TelnetRepository>();
        services.AddScoped<IHostGroupRepository, HostGroupRepository>();
        services.AddScoped<IHostModelRepository, HostModelRepository>();

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<HostRequest>, HostValidation<HostRequest>>();
        services.AddScoped<IValidator<HostPayload>, HostValidation<HostPayload>>();
        services.AddScoped<IValidator<SnmpPayload>, SnmpValidation<SnmpPayload>>();
        services.AddScoped<IValidator<TelnetPayload>, TelnetValidation<TelnetPayload>>();

        return services;
    }
}
