using Application.Contracts;
using Domain.Entities;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
    public UserRepository(AppDBContext dbContext) : base(dbContext)
    {
    }
}