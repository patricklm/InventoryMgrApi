using System.Linq.Expressions;
using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

internal class Repository<T> : IRepository<T> where T : class
{
    protected InventoryContext Context;
    protected DbSet<T> dbSet;

    public Repository(InventoryContext context)
    {
        Context = context;
        dbSet = Context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await dbSet.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        dbSet.AddRange(entities);
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
    }
}
