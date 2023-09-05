using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistance.Contracts
{
    public interface IUserRepository: IGenericRepository<User>
    {

        public User? GetByEmail(string email);
        public Task<List<User>> GetByNameAsync(string name);

    }
}
