using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ProductHubDbContext context) : base(context)
    {
    }
    
    public Task<User?> GetUserByEmail(string email)
    {
        return _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IReadOnlyList<User>> SearchByUsername(string username)
    {
        return await _dbSet.Where(u => u.Username.Contains(username)).ToListAsync();
    }

    public Task<User?> GetUserByUsername(string username)
    {
        return _dbSet.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task ChangeUserRole(User user, Roles role)
    {
        user.Role = role;
        await _context.SaveChangesAsync();
    }
}