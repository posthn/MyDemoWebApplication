namespace DemoWeb.Infrastructure.CQRS;

public class GetWhereQuery<TEntity> : IQuery
{
    public Func<TEntity, bool> Predicate;

    public GetWhereQuery(Func<TEntity, bool> predicate) => Predicate = predicate;
}
