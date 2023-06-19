namespace DemoWeb.Infrastructure.CQRS;

public interface ICommand { };

internal interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
    void Execute(TCommand command);
}
