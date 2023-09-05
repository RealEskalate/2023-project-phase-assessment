using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{   
    private readonly ProductHubDbContext _dbContext;
    
    public UserRepository(ProductHubDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByUserName(string userName)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
    }   
}