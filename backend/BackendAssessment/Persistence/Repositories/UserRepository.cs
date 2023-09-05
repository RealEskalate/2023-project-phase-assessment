using Microsoft.EntityFrameworkCore;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Domain.Entities;

namespace ProductHub.Persistence.Repositories;
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        
        public UserRepository(ProductHubDbContext dbContext) : base(dbContext)
        {
        }

       
    }

