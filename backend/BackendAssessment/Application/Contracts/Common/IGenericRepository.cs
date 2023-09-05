using MediatR;

namespace Application.Contracts.Common;

public interface IGenericRepository<T> where T : class
{
    // create
    public Task<T> CreateAsync(T entity);
    
    // update using guid
    public Task<Unit> UpdateAsync(Guid id, T entity);
    
    // delete using guid
    public Task<Unit> DeleteAsync(Guid id);
    
    // get all
    public Task<IReadOnlyList<T>> GetAllAsync();
    
    // get by id
    public Task<T> GetByIdAsync(Guid id);
    
    // exists
    public Task<bool> Exists(Guid id);
}