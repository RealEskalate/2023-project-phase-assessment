using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendAssessment.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly BackendAssessmentDbContext _dbContext;

    public UserRepository(BackendAssessmentDbContext dbContext) : base(dbContext)
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