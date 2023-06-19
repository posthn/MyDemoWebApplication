using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

public interface IDispatcher<TRepository>
{
    void ExecuteCommand<TCommand>(TCommand command)
        where TCommand : ICommand;

    IQueryable ExecuteQuery<TQuery>(TQuery query)
        where TQuery : IQuery;
}
