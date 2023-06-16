using Microsoft.EntityFrameworkCore;

namespace DemoWeb.Infrastructure.EntityFrameworkCore;

internal sealed class DbContextBase : DbContext
{
    private Type[] _models;

    public DbContextBase(DbContextOptions<DbContextBase> options, params Type[] models)
        : base(options)
    {
        if (models == null)
            throw new ArgumentNullException(nameof(models));
        _models = models;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var model in _models)
        {
            if (modelBuilder.Model.FindEntityType(model) != null)
                continue;
            modelBuilder.Model.AddEntityType(model);
        }
    }
}
