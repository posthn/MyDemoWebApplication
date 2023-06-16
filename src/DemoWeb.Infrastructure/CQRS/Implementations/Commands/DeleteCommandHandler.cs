using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class DeleteCommandHandler<CreateCommand, TEntity>
    : ICommandHandler<CreateCommand<TEntity>, TEntity>
    where TEntity : class
{
    private IRepository _repository;

    public DeleteCommandHandler(IRepository repository) => _repository = repository;

    public void Execute(CreateCommand<TEntity> command) => _repository.Delete(command.Entity);
}
