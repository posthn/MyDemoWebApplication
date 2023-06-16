using Microsoft.EntityFrameworkCore;
using DemoWeb.Infrastructure.EntityFrameworkCore;

namespace DemoWeb.Infrastructure.Repositories;

internal abstract class RepositoryBase : IRepository
{
    private DbContextBase _context;

    public RepositoryBase(DbContextBase context) => _context = context;

    public async Task Save<TEntity>(TEntity obj)
        where TEntity : class
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public IQueryable<TEntity> Get<TEntity>()
        where TEntity : class => _context.Set<TEntity>();

    public async Task Update<TEntity>(TEntity obj)
        where TEntity : class
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        _context.Update(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Delete<TEntity>(TEntity obj)
        where TEntity : class
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        _context.Entry(obj).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}
