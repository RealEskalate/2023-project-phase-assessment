using Application.Contracts.Persistance;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;

namespace Persistence.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ProductHubDbContext _dbContext;

    public UserRepository(ProductHubDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByUserName(string Username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == Username);
    }

}