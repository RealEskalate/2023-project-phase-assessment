using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    private readonly ProductHubDbContext _dbContext;

    public GenericRepository(ProductHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await GetAsync(id);
        return entity != null;
    }

    public async Task<T> GetAsync(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        return entity!;
    }

    public async Task UpdateAsync(int id, T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task<List<T>> GetAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        var entity = await GetAsync(id);
        return entity != null;
    }
}
