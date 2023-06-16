using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class CreateCommandHandler<CreateCommand, TEntity>
    : ICommandHandler<CreateCommand<TEntity>, TEntity>
    where TEntity : class
{
    private IRepository _repository;

    public CreateCommandHandler(IRepository repository) => _repository = repository;

    public void Execute(CreateCommand<TEntity> command) => _repository.Save(command.Entity);
}
