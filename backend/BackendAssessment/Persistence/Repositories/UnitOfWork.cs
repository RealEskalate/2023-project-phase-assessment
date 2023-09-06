using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persisitence;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductHubDbContext _dbContext;

        private ProductRepository? _productRepository;
        private CatagoryRepository? _catagoryRepository;

        public UnitOfWork(ProductHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_dbContext);
        public ICatagoryRepository CatagoryRepository => 
                _catagoryRepository ??= new CatagoryRepository(_dbContext);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}