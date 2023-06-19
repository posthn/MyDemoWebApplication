namespace DemoWeb.Infrastructure.CQRS;

public class CreateCommand<TEntity> : ICommand
{
    public TEntity Entity { get; }

    public CreateCommand(TEntity entity) => Entity = entity;
}
