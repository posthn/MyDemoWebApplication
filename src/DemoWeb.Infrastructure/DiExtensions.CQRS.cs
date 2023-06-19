using Microsoft.Extensions.DependencyInjection;
using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

public static partial class DependencyInjectionExtensions
{
    public static IServiceCollection AddCQRS<TRepository>(
        this IServiceCollection services,
        params Type[] models
    )
        where TRepository : IRepository
    {
        if (models == null)
            throw new ArgumentNullException(nameof(models));

        var startIndex = models.Length - 1;

        services.AddTransient<ICommandDispatcher, CommandDispatcher>();

        services.AddServices<TRepository>(
            typeof(CreateCommand<>),
            typeof(ICommandHandler<,>),
            typeof(CreateCommandHandler<,,>),
            models,
            startIndex
        );

        services.AddServices<TRepository>(
            typeof(UpdateCommand<>),
            typeof(ICommandHandler<,>),
            typeof(UpdateCommandHandler<,,>),
            models,
            startIndex
        );

        services.AddServices<TRepository>(
            typeof(DeleteCommand<>),
            typeof(ICommandHandler<,>),
            typeof(DeleteCommandHandler<,,>),
            models,
            startIndex
        );

        //...

        services.AddTransient<IQueryDispatcher, QueryDispatcher>();

        services.AddServices<TRepository>(
            typeof(GetAllQuery<>),
            typeof(IQueryHandler<,>),
            typeof(GetAllQueryHandler<,,>),
            models,
            startIndex
        );

        services.AddServices<TRepository>(
            typeof(GetWhereQuery<>),
            typeof(IQueryHandler<,>),
            typeof(GetWhereQueryHandler<,,>),
            models,
            startIndex
        );

        //...

        services.AddScoped<IDispatcher, Dispatcher>();

        return services;
    }

    private static IServiceCollection AddServices<TRepository>(
        this IServiceCollection services,
        Type operationType,
        Type serviceType,
        Type handlerType,
        Type[] models,
        int index
    )
        where TRepository : IRepository
    {
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        var service = serviceType.MakeGenericType(
            operationType.MakeGenericType(models[index]),
            models[index]
        );

        var implementation = handlerType.MakeGenericType(
            typeof(TRepository),
            operationType.MakeGenericType(models[index]),
            models[index]
        );

        return index == 0
            ? services.AddTransient(service, implementation)
            : AddServices<TRepository>(
                services,
                operationType,
                serviceType,
                handlerType,
                models,
                (index - 1)
            );
    }
}
