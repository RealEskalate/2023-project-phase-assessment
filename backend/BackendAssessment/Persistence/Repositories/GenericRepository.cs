using Application.Contracts.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDBContext _dbContext;

    public GenericRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<T> CreateAsync(T entity)
    {
        var newItem = await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return newItem.Entity;
    }

    public async Task<Unit> UpdateAsync(Guid id, T entity)
    {
        var item = await _dbContext.Set<T>().FindAsync(id);
        
        if (item == null)
            return Unit.Value;
        
        _dbContext.Entry(item).CurrentValues.SetValues(entity);
        
        await _dbContext.SaveChangesAsync();
        
        return Unit.Value;
    }

    public async Task<Unit> DeleteAsync(Guid id)
    {
        var item = await _dbContext.Set<T>().FindAsync(id);
        
        if (item == null)
            return Unit.Value;
        
        _dbContext.Set<T>().Remove(item);
        
        await _dbContext.SaveChangesAsync();
        
        return Unit.Value;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<bool> Exists(Guid id)
    {
        var item = await _dbContext.Set<T>().FindAsync(id);
        
        return item != null;
    }
}