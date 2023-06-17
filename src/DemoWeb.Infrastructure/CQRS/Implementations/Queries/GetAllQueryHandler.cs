using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class GetAllQueryHandler<TRepository, GetAllQuery, TEntity>
    : IQueryHandler<GetAllQuery<TEntity>, TEntity>
    where TRepository : IRepository
    where TEntity : class
{
    private IRepository _repository;

    public GetAllQueryHandler(TRepository repository) => _repository = repository;

    public IQueryable<TEntity> Execute(GetAllQuery<TEntity> query) => _repository.Get<TEntity>();
}
