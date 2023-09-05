using Application.Contracts.persistence;
using Application.Exceptions;
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
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext): base(appDbContext)
        {

            _appDbContext = appDbContext;
        }

        public User? GetByEmail(string email)
        {
            var users = _appDbContext.Users.SingleOrDefault(u => u.Email == email);
            return users;
        }

        public void AddUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        public async Task<IReadOnlyList<User>> GetByNameAsync(string Name)
        {
            var users = await _appDbContext.Users.Where(u => u.Username.Contains(Name)).ToListAsync() ?? throw new NotFoundException("${Name}", Name);
            return users;
        }
    }
}
