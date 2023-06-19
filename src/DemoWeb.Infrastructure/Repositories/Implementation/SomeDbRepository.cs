namespace DemoWeb.Infrastructure.Repositories;

///<summary>
///Pattern for new service implementation.
///</summary>
internal sealed class SomeDbRepository : RepositoryBase, ISomeDbRepository
{
    public SomeDbRepository(DbContextBase context)
        : base(context) { }
}
