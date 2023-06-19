using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class GetWhereQueryHandler<TRepository, TEntity> : IQueryHandler<GetWhereQuery<TEntity>>
    where TRepository : IRepository
    where TEntity : class
{
    public IRepository _repository;

    public GetWhereQueryHandler(TRepository repository) => _repository = repository;

    public IQueryable Execute(GetWhereQuery<TEntity> query) =>
        _repository.Get<TEntity>().Where(query.Predicate).AsQueryable<TEntity>();
}
