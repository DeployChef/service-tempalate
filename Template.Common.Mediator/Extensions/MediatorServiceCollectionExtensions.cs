using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Common.Mediator.Extensions;

public static class MediatorServiceCollectionExtensions
{
    public static IServiceCollection AddMediatR(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

        return services;
    }
}