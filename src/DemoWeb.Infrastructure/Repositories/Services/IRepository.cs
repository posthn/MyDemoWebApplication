namespace DemoWeb.Infrastructure.Repositories;

public interface IRepository
{
    Task Save<TEntity>(TEntity objs)
        where TEntity : class;

    IQueryable<TEntity> Get<TEntity>()
        where TEntity : class;

    Task Update<TEntity>(TEntity obj)
        where TEntity : class;

    Task Delete<TEntity>(TEntity objs)
        where TEntity : class;
}
