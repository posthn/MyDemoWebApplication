namespace DemoWeb.Infrastructure.CQRS;

public interface IQuery { }

public interface IQuery<TEntity> : IQuery { }

internal interface IQueryHandler<TQuery, TEntity>
    where TQuery : IQuery<TEntity>
{
    IQueryable<TEntity> Execute(TQuery query);
}

internal interface IQueryDispatcher
{
    IQueryable<TEntity> Execute<TQuery, TEntity>(TQuery query)
        where TQuery : IQuery<TEntity>;
}
