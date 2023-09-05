

using MediatR;

namespace Application.Contracts.Common;

public interface IGenericRepository<T> where T : class
{
    public Task<T> CreateAsync(T new_entity,CancellationToken cancellationToken);
    public Task<T> UpdateAsync(T existing_entity,T update_entity,CancellationToken cancellationToken);
    public Task<Unit> DeleteAsync(T delete_entity,CancellationToken cancellationToken);
    public Task<T> GetSingleAsync(Guid Id,CancellationToken cancellationToken);
    public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
}