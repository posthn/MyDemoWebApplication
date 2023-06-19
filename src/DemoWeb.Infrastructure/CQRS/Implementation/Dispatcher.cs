using Microsoft.Extensions.DependencyInjection;
using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class Dispatcher<TRepository> : IDispatcher<TRepository>
    where TRepository : IRepository
{
    private IServiceProvider _provider;

    public Dispatcher(IServiceProvider provider) => _provider = provider;

    public void ExecuteCommand<TCommand>(TCommand command)
        where TCommand : ICommand
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));

        var handler = _provider.GetRequiredService<ICommandHandler<TCommand>>();
        if (handler == null)
            throw new NullReferenceException(nameof(handler));

        handler.Execute(command);
    }

    public IQueryable ExecuteQuery<TQuery>(TQuery query)
        where TQuery : IQuery
    {
        if (query == null)
            throw new ArgumentNullException(nameof(query));

        var handler = _provider.GetRequiredService<IQueryHandler<TQuery>>();
        if (handler == null)
            throw new NullReferenceException(nameof(handler));

        return handler.Execute(query);
    }
}
