using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class GetWhereQueryHandler<TRepository, GetWhereQuery, TEntity>
    : IQueryHandler<GetWhereQuery<TEntity>, TEntity>
    where TRepository : IRepository
    where TEntity : class
{
    private IRepository _repository;

    public GetWhereQueryHandler(TRepository repository) => _repository = repository;

    public IQueryable<TEntity> Execute(GetWhereQuery<TEntity> query) =>
        _repository.Get<TEntity>().Where(query.Predicate).AsQueryable<TEntity>();
}
