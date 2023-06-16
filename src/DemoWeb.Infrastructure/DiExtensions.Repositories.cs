using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DemoWeb.Infrastructure.Repositories;

public static partial class DependencyInjectionExtensions
{
    public static IServiceCollection AddSQLiteRepository(
        this IServiceCollection services,
        string connectionString,
        params Type[] models
    )
    {
        var options = new DbContextOptionsBuilder<DbContextBase>()
            .UseSqlite(connectionString)
            .Options;

        var dbContext = new DbContextBase(options, models);

        return services.AddScoped<ISQLiteRepository, SQLiteRepository>(
            provider => new SQLiteRepository(dbContext)
        );
    }

    ///<summary>
    ///Pattern for adding a new dependency.
    ///</summary>
    private static IServiceCollection AddSomeDbRepository(
        this IServiceCollection services,
        string connectionString,
        params Type[] models
    )
    {
        var options = new DbContextOptionsBuilder<DbContextBase>()
        //    .UseSomeDb(connectionString)
        .Options;

        var dbContext = new DbContextBase(options, models);

        return services.AddScoped<ISomeDbRepository, SomeDbRepository>(
            provider => new SomeDbRepository(dbContext)
        );
    }
}
