namespace DemoWeb.Infrastructure.CQRS;

public interface ICommand { }

public interface ICommand<TEntity> : ICommand { }

internal interface ICommandHandler<TCommand, TEntity>
    where TCommand : ICommand<TEntity>
{
    void Execute(TCommand command);
}

internal interface ICommandDispatcher
{
    void Execute<TCommand, TEntity>(TCommand command)
        where TCommand : ICommand<TEntity>;
}
