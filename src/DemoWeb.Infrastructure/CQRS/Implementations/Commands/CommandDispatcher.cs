using Microsoft.Extensions.DependencyInjection;

namespace DemoWeb.Infrastructure.CQRS;

internal class CommandDispatcher : ICommandDispatcher
{
    private IServiceProvider _provider;

    public CommandDispatcher(IServiceProvider provider) => _provider = provider;

    public void Execute<TCommand, TEntity>(TCommand command)
        where TCommand : ICommand<TEntity>
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));

        var handler =
            (ICommandHandler<TCommand, TEntity>)
                _provider.GetRequiredService(typeof(ICommandHandler<TCommand, TEntity>));

        if (handler == null)
            throw new NullReferenceException(nameof(handler));

        handler.Execute(command);
    }
}
