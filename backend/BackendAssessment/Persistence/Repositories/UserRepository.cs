using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using ProductHub.Domain.Entites;


namespace ProductHub.Persistence.Repositories;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ProductHubDbContext _dbContext;
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
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName == username);
        return user!;
    }



    public async Task<bool> UsernameExists(string username)
    {
        return await _dbContext.Users.AnyAsync(user => user.UserName == username);
    }

}
