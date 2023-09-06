using Application.Contracts.persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext): base(appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task<List<Product>> GetProductByUserId(Guid userId)
        {
            var products = await _appDbContext.Products.Where(p=>p.UserId == userId).ToListAsync();
            return products;
        }
    }
}
