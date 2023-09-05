using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BackendAssessmentDbContext dbContext) : base(dbContext)
    {
    }

    public async Task GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task GetAsync()
    {
        throw new NotImplementedException();
    }

   
    public async  Task<bool> UsernameExists(string username)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EmailExists(string email)
    {
        throw new NotImplementedException();
    }

    public async  Task<User> GetByUsername(string username)
    {
        throw new NotImplementedException();
    }
}