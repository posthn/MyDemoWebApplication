using DemoWeb.Infrastructure.Repositories;

namespace DemoWeb.Infrastructure.CQRS;

internal class UpdateCommandHandler<CreateCommand, TEntity>
    : ICommandHandler<CreateCommand<TEntity>, TEntity>
    where TEntity : class
{
    private IRepository _repository;

    public UpdateCommandHandler(IRepository repository) => _repository = repository;

    public void Execute(CreateCommand<TEntity> command) => _repository.Update(command.Entity);
}
