namespace DemoWeb.Infrastructure.Repositories;

internal sealed class SQLiteRepository : RepositoryBase, ISQLiteRepository
{
    public SQLiteRepository(DbContextBase context)
        : base(context) { }
}
