using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using DAL.Contracts;
using DAL.Models;

namespace DAL.Repositories;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly CSContext databaseContext;
    protected readonly DbSet<TEntity> table;

    public GenericRepository(CSContext databaseContext)
    {
        this.databaseContext = databaseContext;
        table = this.databaseContext.Set<TEntity>();
    }

    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await table.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await table.ToListAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
        }

        await table.AddAsync(entity);
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
        }
        await Task.Run(() => table.Update(entity));

    }
    public virtual async Task DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        await Task.Run(() => table.Remove(entity));
    }
}