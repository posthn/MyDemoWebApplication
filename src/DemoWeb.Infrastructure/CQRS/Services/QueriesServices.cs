namespace DemoWeb.Infrastructure.CQRS;

public interface IQuery<TEntity> { }

internal interface IQueryHandler<TQuery, TEntity>
    where TQuery : IQuery<TEntity>
{
    IQueryable<TEntity> Execute(TQuery query);
}

public interface IQueryDispatcher
{
    IQueryable<TEntity> Execute<TQuery, TEntity>(TQuery query)
        where TQuery : IQuery<TEntity>;
}
