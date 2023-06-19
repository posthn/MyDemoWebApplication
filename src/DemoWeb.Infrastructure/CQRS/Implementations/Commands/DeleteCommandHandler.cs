using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class DeleteCommandHandler<TRepository, DeleteCommand, TEntity>
    : ICommandHandler<DeleteCommand<TEntity>, TEntity>
    where TRepository : IRepository
    where TEntity : class
{
    private IRepository _repository;

    public DeleteCommandHandler(TRepository repository) => _repository = repository;

    public void Execute(DeleteCommand<TEntity> command) => _repository.Delete(command.Entity);
}
