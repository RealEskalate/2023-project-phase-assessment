﻿using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface IUserRepository:IGenericRepository<User>
    {
        public void AddUser(User user);
        public User? GetByEmail(string email);
        Task<IReadOnlyList<User>> GetByNameAsync(string name);

    }
}
