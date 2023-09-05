﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGenericRepository<T>
    {
        public Task<T> Get(int Id);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(T entit );
        
    }
}
