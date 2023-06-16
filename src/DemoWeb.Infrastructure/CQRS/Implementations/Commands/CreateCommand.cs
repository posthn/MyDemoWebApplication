namespace DemoWeb.Infrastructure.CQRS;

public class CreateCommand<TEntity> : ICommand<TEntity>
{
    public TEntity Entity { get; }

    public CreateCommand(TEntity entity) => Entity = entity;
}
