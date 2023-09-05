using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AssessmentDbContext _dbContext;

    protected GenericRepository(AssessmentDbContext dbContext)
    {
        _dbContext = dbContext;
    } 
    
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbContext.FindAsync<T>(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        var response = await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return response.Entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task? DeleteAsync(int id)
    {
        var res = await _dbContext.Set<T>().FindAsync(id);
        if (res == null) return;
        _dbContext.Entry(res).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id) != null;
    }
}