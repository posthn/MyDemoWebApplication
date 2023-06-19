using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class UpdateCommandHandler<TRepository, UpdateCommand, TEntity>
    : ICommandHandler<UpdateCommand<TEntity>, TEntity>
    where TRepository : IRepository
    where TEntity : class
{
    private IRepository _repository;

    public UpdateCommandHandler(TRepository repository) => _repository = repository;

    public void Execute(UpdateCommand<TEntity> command) => _repository.Update(command.Entity);
}
