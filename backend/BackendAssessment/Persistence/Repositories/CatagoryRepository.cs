using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;
using Domain.Entites;

namespace Persistence.Repositories
{
    public class CatagoryRepository : GenericRepository<Catagory>, ICatagoryRepository
    {
        private readonly ProductHubDbContext _dbContext;

        public CatagoryRepository(ProductHubDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}