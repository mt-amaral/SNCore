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
        services.AddScoped<IHardwareService, HardwareService>();
        services.AddScoped<ISnmpService, SnmpService>();
        services.AddScoped<ITelnetService, TelnetService>();

        return services;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IHardwareRepository, HardwareRepository>();
        services.AddScoped<ISnmpRepository, SnmpRepository>();
        services.AddScoped<ITelnetRepository, TelnetRepository>();

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<HardwareRequest>, HardwareValidation<HardwareRequest>>();
        services.AddScoped<IValidator<HardwarePayload>, HardwareValidation<HardwarePayload>>();

        services.AddScoped<IValidator<SnmpRequest>, SnmpValidation<SnmpRequest>>();
        services.AddScoped<IValidator<SnmpPayload>, SnmpValidation<SnmpPayload>>();

        services.AddScoped<IValidator<TelnetRequest>, TelnetValidation<TelnetRequest>>();
        services.AddScoped<IValidator<TelnetPayload>, TelnetValidation<TelnetPayload>>();

        return services;
    }
}
