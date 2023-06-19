namespace DemoWeb.Infrastructure.CQRS;

internal class Dispatcher : IDispatcher
{
    private ICommandDispatcher _commandDispatcher;
    private IQueryDispatcher _queryDispatcher;

    public Dispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    public void ExecuteCommand<TCommand>(TCommand command)
        where TCommand : ICommand
    {
        var entityType = typeof(TCommand).GenericTypeArguments.First();

        var handleMethod = typeof(ICommandDispatcher).GetMethod(nameof(ICommandDispatcher.Execute));
        if (handleMethod == null)
            throw new NullReferenceException(nameof(handleMethod));

        handleMethod
            .MakeGenericMethod(typeof(TCommand), entityType)
            .Invoke(_commandDispatcher, new object[] { command });
    }

    public IQueryable? ExecuteQuery<TQuery>(TQuery query)
        where TQuery : IQuery
    {
        var entityType = typeof(TQuery).GenericTypeArguments.First();

        var handleMethod = typeof(IQueryDispatcher).GetMethod(nameof(IQueryDispatcher.Execute));
        if (handleMethod == null)
            throw new NullReferenceException(nameof(handleMethod));

        return (IQueryable?)
            handleMethod
                .MakeGenericMethod(typeof(TQuery), entityType)
                .Invoke(_queryDispatcher, new object[] { query });
    }
}
