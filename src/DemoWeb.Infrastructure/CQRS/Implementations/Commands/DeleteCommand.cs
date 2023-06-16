namespace DemoWeb.Infrastructure.CQRS;

public class DeleteCommand<TEntity> : ICommand<TEntity>
{
    public TEntity Entity { get; }

    public DeleteCommand(TEntity entity) => Entity = entity;
}
