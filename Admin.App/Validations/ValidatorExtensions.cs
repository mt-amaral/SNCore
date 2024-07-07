using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Admin.App.Validations
{
    public static class ValidatorExtensions
    {
        public static void AddValidators(this IServiceCollection services, Type[] typesFromAssemblies)
        {
            var validators = typesFromAssemblies
                .SelectMany(t => t.Assembly.ExportedTypes)
                .Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo(typeof(IValidator)))
                .ToList();

            foreach (var validator in validators)
            {
                var interfaceType = validator.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>));
                if (interfaceType != null)
                {
                    services.AddTransient(interfaceType, validator);
                }
            }
        }
    }
}
