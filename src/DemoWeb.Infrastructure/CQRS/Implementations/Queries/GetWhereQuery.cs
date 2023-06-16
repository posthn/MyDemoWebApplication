namespace DemoWeb.Infrastructure.CQRS;

public class GetWhereQuery<TEntity> : IQuery<TEntity>
{
    internal Func<TEntity, bool> Predicate { get; }

    public GetWhereQuery(Func<TEntity, bool> predicate) => Predicate = predicate;
}
