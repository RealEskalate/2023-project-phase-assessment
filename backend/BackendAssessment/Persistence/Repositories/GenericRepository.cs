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

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }

    public async Task<bool> Exists(Guid id)
    {
        var entity = await GetAsync(id);
        return entity != null;
    }

    public async Task<T> GetAsync(Guid id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        return entity!;
    }

    public Task UpdateAsync(Guid id, T entity)
    {

        _dbContext.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }


    public async Task<List<T>> GetAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        var entity = await GetAsync(id);
        return entity != null;
    }
}
