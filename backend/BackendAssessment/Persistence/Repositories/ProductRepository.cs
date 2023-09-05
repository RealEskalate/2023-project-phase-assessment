using Domain.Entites;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Persistence.Repositories;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        private readonly ApiDbContext _dbContext;
        public ProductRepository(ApiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
