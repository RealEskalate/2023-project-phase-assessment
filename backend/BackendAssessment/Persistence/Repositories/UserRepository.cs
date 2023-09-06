using Application.Persistence.Repositories;
using Domain.Entites;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        private readonly ApiDbContext _dbContext;
        public UserRepository(ApiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<User> GetByEmail(string email)
        //{
        //    return await _dbContext.Set<User>()
        //        .Where(u => u.email == email)
                
        //}

        //public async Task<List<User>> GetByNameEmail(string email)
        //{
        //    return await _dbContext.Set<User>()
        //        .Where(u => u.username == email || u.email == email)
        //        .ToListAsync();
        //}
    }
}
