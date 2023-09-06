using Application.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Entites;
using Infrastructure.Data;
using Application.Persistance.Contracts;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApiDbContext _dbContext;
        public UserRepository(ApiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.Set<User>()
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetByNameEmail(string email)
        {
            return await _dbContext.Set<User>()
                .Where(u => u.Username == email || u.Email == email)
                .ToListAsync();
        }
    }
}