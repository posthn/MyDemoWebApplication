using Microsoft.Extensions.DependencyInjection;

namespace DemoWeb.Infrastructure.CQRS;

internal class QueryDispatcher : IQueryDispatcher
{
    private IServiceProvider _provider;

    public QueryDispatcher(IServiceProvider provider) => _provider = provider;

    public IQueryable<TEntity> Execute<TQuery, TEntity>(TQuery query)
        where TQuery : IQuery<TEntity>
    {
        if (query == null)
            throw new ArgumentNullException(nameof(query));

        var handler =
            (IQueryHandler<TQuery, TEntity>)
                _provider.GetRequiredService(typeof(IQueryHandler<TQuery, TEntity>));

        if (handler == null)
            throw new NullReferenceException(nameof(handler));

        return handler.Execute(query);
    }
}
