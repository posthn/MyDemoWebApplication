namespace DemoWeb.Infrastructure.CQRS;

public class UpdateCommand<TEntity> : ICommand
{
    public TEntity Entity { get; }

    public UpdateCommand(TEntity entity) => Entity = entity;
}
