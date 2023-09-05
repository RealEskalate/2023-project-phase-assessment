using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Reposiotories;

public class UserRepository : GenericReposiotry<User>, IUserRepository
{

    private readonly ProductHubDbContext _dbContext;
    private readonly DbSet<User> _dbSet;

    public UserRepository(ProductHubDbContext dbContext ) : base(dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<User>();
    }

    public Task<bool> ExistsByEmailAsync(string email)
    {
    return _dbSet.AnyAsync(u => u.Email == email);
    }

    public Task<bool> ExistsByUsernameAsync(string username)
    {
        return _dbSet.AnyAsync(u => u.Username == username);
    }

    public Task<User?> GetByEmailAsync(string email)
    {
       return _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        return _dbSet.FirstOrDefaultAsync(u => u.Username == username);
    }
}