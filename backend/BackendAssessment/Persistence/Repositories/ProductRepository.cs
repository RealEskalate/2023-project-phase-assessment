using Application.Persistance.Contracts;
using Application.Persistence.Repositories;
using Domain.Entites;
using Infrastructure.Data;

namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}