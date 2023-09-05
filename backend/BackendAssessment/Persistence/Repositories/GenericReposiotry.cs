using Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Reposiotories;

public class GenericReposiotry<T> : IGenericRepository<T> where T : class
{
     private readonly ProductHubDbContext _dbContext;

    public GenericReposiotry(ProductHubDbContext dbContext)
    {
        _dbContext = dbContext;
    
    }
    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task<bool> ExistsAsync(int id)
    {
       return await  _dbContext.Set<T>().FindAsync(id) != null;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        await Task.CompletedTask;
    }
}