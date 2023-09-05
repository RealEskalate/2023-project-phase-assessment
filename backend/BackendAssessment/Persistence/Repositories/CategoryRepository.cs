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
    public class CategoryRepository : GenericRepository<Category>
    {
        private readonly ApiDbContext _context;
        public CategoryRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
