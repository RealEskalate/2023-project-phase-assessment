using Application.Contracts.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        protected GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity,CancellationToken cancellationToken)
        {
            var res = await _dbContext.Set<T>().AddAsync(entity,cancellationToken);
        
            await _dbContext.SaveChangesAsync(cancellationToken);
            return res.Entity;
        }

        public async Task<Unit> DeleteAsync(T entity,CancellationToken cancellationToken)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetSingleAsync(Guid Id,CancellationToken cancellationToken)
        {
            var item = await _dbContext.Set<T>().FindAsync(Id,cancellationToken);
            return item;
        }

        public async Task<T> UpdateAsync(T old_entity, T update_entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(old_entity).CurrentValues.SetValues(update_entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return old_entity; 
        }
    }
}