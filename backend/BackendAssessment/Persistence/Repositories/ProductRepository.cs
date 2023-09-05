using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;
using  Application.Contracts;
namespace Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(SocialMediaDbContext _Context) : base(_Context){}

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll(int userId)
        {
            throw new NotImplementedException();
        }
    }
}