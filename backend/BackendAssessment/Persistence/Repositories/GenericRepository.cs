using Microsoft.EntityFrameworkCore;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    private readonly BackendAssessmentDbContext _dbContext;

    public GenericRepository(BackendAssessmentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
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

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task<List<T>> GetAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        var existingEntity = await _dbContext.Set<T>().FindAsync(id);
        return existingEntity != null;
    }
}