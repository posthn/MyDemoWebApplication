using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class GetWhereQueryHandler<GetWhereQuery, TEntity>
    : IQueryHandler<GetWhereQuery<TEntity>, TEntity>
    where TEntity : class
{
    private IRepository _repository;

    public GetWhereQueryHandler(IRepository repository) => _repository = repository;

    public IQueryable<TEntity> Execute(GetWhereQuery<TEntity> query) =>
        _repository.Get<TEntity>().Where(query.Predicate).AsQueryable<TEntity>();
}
