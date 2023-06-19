namespace DemoWeb.Infrastructure.CQRS;

public interface IDispatcher
{
    public void ExecuteCommand<TCommand>(TCommand command)
        where TCommand : ICommand;

    public IQueryable? ExecuteQuery<TQuery>(TQuery query)
        where TQuery : IQuery;
}
