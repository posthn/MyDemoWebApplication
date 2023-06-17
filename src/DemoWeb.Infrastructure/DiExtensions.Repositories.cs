using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DemoWeb.Infrastructure.Repositories;

public static partial class DependencyInjectionExtensions
{
    private static IServiceCollection AddRepository<TService, TImplementation>(
        this IServiceCollection services,
        DbContextOptions<DbContextBase> options,
        Type[] models
    )
        where TService : class, IRepository
        where TImplementation : RepositoryBase, TService
    {
        var dbContext = new DbContextBase(options, models);

        var constructor = typeof(TImplementation).GetConstructor(new[] { typeof(DbContextBase) });
        if (constructor == null)
            throw new NullReferenceException(nameof(constructor));

        return services.AddScoped<TService, TImplementation>(
            provider => (TImplementation)constructor.Invoke(new[] { dbContext })
        );
    }

    public static IServiceCollection AddSQLiteRepository(
        this IServiceCollection services,
        string connectionString,
        params Type[] models
    )
    {
        var options = new DbContextOptionsBuilder<DbContextBase>()
            .UseSqlite(connectionString)
            .Options;

        return services.AddRepository<ISQLiteRepository, SQLiteRepository>(options, models);
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
        //.UseSomeDb(connectionString)
        .Options;

        return services.AddRepository<ISomeDbRepository, SomeDbRepository>(options, models);
    }
}
