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
        if (models == null || models.Length == 0)
            throw new ArgumentNullException(nameof(models));

        var startIndex = models.Length - 1;

        services.AddScoped<IDispatcher<TRepository>, Dispatcher<TRepository>>();

        ///<summary>
        ///Registering a create command handler.
        ///</summary>
        services.AddHandlersFor<TRepository>(
            typeof(CreateCommand<>),
            typeof(ICommandHandler<>),
            typeof(CreateCommandHandler<,>),
            models,
            startIndex
        );

        ///<summary>
        ///Registering a delete command handler.
        ///</summary>
        services.AddHandlersFor<TRepository>(
            typeof(DeleteCommand<>),
            typeof(ICommandHandler<>),
            typeof(DeleteCommandHandler<,>),
            models,
            startIndex
        );

        ///<summary>
        ///Registering a update command handler.
        ///</summary>
        services.AddHandlersFor<TRepository>(
            typeof(UpdateCommand<>),
            typeof(ICommandHandler<>),
            typeof(UpdateCommandHandler<,>),
            models,
            startIndex
        );

        // Registering new command handlers.
        // ...

        ///<summary>
        ///Registering a "GetAll" query handler.
        ///</summary>
        services.AddHandlersFor<TRepository>(
            typeof(GetAllQuery<>),
            typeof(IQueryHandler<>),
            typeof(GetAllQueryHandler<,>),
            models,
            startIndex
        );

        ///<summary>
        ///Registering a "GetWhere" query handler.
        ///</summary>
        services.AddHandlersFor<TRepository>(
            typeof(GetWhereQuery<>),
            typeof(IQueryHandler<>),
            typeof(GetWhereQueryHandler<,>),
            models,
            startIndex
        );

        // Registering new query handlers.
        // ...

        return services;
    }

    private static IServiceCollection AddHandlersFor<TRepository>(
        this IServiceCollection services,
        Type operationType,
        Type serviceType,
        Type implementationType,
        Type[] models,
        int index
    )
        where TRepository : IRepository
    {
        var service = serviceType.MakeGenericType(operationType.MakeGenericType(models[index]));

        var implementation = implementationType.MakeGenericType(typeof(TRepository), models[index]);

        return index == 0
            ? services.AddTransient(service, implementation)
            : AddHandlersFor<TRepository>(
                services,
                operationType,
                serviceType,
                implementationType,
                models,
                (index - 1)
            );
    }
}
