
using Application.Contracts;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<UserEntity>,IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}