using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class GetAllQueryHandler<TRepository, TEntity> : IQueryHandler<GetAllQuery<TEntity>>
    where TRepository : IRepository
    where TEntity : class
{
    public IRepository _repository;

    public GetAllQueryHandler(TRepository repository) => _repository = repository;

    public IQueryable Execute(GetAllQuery<TEntity> query) => _repository.Get<TEntity>();
}
