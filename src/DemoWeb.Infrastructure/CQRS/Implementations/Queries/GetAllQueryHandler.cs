using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class GetAllQueryHandler<GetAllQuery, TEntity>
    : IQueryHandler<GetAllQuery<TEntity>, TEntity>
    where TEntity : class
{
    private IRepository _repository;

    public GetAllQueryHandler(IRepository repository) => _repository = repository;

    public IQueryable<TEntity> Execute(GetAllQuery<TEntity> query) => _repository.Get<TEntity>();
}
