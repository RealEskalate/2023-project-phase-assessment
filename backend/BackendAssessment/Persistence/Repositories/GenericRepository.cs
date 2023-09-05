using Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ProductHubDbContext _dbContext;

        public GenericRepository(ProductHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return true;

        }

        public async Task<bool> Exists(int id)
        {
            var result = _dbContext.Set<T>().FindAsync(id);
            return result != null;
        }

        public async Task<List<T>> GetAll()
        {
            var result = await _dbContext.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetbyId(int id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);
            return result;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
