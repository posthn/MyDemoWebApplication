using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class CreateCommandHandler<TRepository, TEntity> : ICommandHandler<CreateCommand<TEntity>>
    where TRepository : IRepository
    where TEntity : class
{
    private IRepository _repository;

    public CreateCommandHandler(TRepository repository) => _repository = repository;

    public void Execute(CreateCommand<TEntity> command) => _repository.Save(command.Entity);
}
