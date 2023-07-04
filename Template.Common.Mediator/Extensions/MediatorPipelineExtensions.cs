using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Template.Common.Data.Interfaces;
using Template.Common.Mediator.Pipelines;

namespace Template.Common.Mediator.Extensions;

public static class MediatorPipelineExtensions
{
    public static IServiceCollection UseMediatorLogging(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }

    public static IServiceCollection UseMediatorExceptionHandler(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));

        return services;
    }

    public static IServiceCollection UseMediatorTransaction<TUnitOfWork>(this IServiceCollection services) where TUnitOfWork : IUnitOfWork
    {
        services.AddScoped<IUnitOfWork>(p => p.GetRequiredService<TUnitOfWork>());
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

        return services;
    }
}