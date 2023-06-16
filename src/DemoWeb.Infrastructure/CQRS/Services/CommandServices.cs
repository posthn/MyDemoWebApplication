namespace DemoWeb.Infrastructure.CQRS;

public interface ICommand<TEntity> { }

internal interface ICommandHandler<TCommand, TEntity>
    where TCommand : ICommand<TEntity>
{
    void Execute(TCommand command);
}

public interface ICommandDispatcher
{
    void Execute<TCommand, TEntity>(TCommand command)
        where TCommand : ICommand<TEntity>;
}
