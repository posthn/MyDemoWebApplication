namespace DemoWeb.Infrastructure.CQRS;

public interface IQuery { }

internal interface IQueryHandler<TQuery>
    where TQuery : IQuery
{
    IQueryable Execute(TQuery query);
}
