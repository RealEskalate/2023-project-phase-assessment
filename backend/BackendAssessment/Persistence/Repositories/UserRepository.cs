using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private ProductHubDbContext _dbContext;

    public UserRepository(ProductHubDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> EmailExists(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email == email);
    }

    public async Task<User> GetByUsername(string username)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username == username);
        return user!;
    }

    public async Task<bool> UserIsAdminAsync(Guid userId)
    {
       var user = await GetAsync(userId); 
       return user.Role == UserRole.ADMIN;
    }

    public async Task<bool> UsernameExists(string username)
    {
        return await _dbContext.Users.AnyAsync(user => user.Username == username);
    }
}
