using Application.Exceptions;
using Application.Persistance.Contracts;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ProductHubDbContext _dbContext;
        public UserRepository(ProductHubDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public User? GetByEmail(string email)
        {
            var users = _dbContext.Users.SingleOrDefault(u => u.Email == email);
            return users;
        }



        public async Task<List<User>> GetByNameAsync(string Name)
        {
            var users = _dbContext.Users.Where(u => u.Name.Contains(Name)).ToList() ?? throw new NotFoundException("${Name}", Name);
            return users;
        }

        
    }
}
