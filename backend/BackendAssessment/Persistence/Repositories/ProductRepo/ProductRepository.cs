using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using Persistence.Data;

namespace Persistence.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            if (_context.SaveChanges() <= 0)
            {
                return Task.FromResult<Product>(null);
            }
            return Task.FromResult(product);

        }

        public Task<Product> DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            if (_context.SaveChanges() <= 0)
            {
                return Task.FromResult<Product>(null);
            }
            return Task.FromResult(product);
        }

        public Task<bool> Exists(int id)
        {
            return Task.FromResult(_context.Products.Find(id) != null);
        }

        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(_context.Products.ToList());
        }

        public Task<Product> GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            return Task.FromResult(product);
        }

        public Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            if (_context.SaveChanges() <= 0)
            {
                return Task.FromResult<Product>(null);
            }
            return Task.FromResult(product);
        }
    }
}