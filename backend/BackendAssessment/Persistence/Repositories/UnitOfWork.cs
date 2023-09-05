using Application.Contracts.Persistance;
using Persistence.Repository;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductHubDbContext _dbContext;
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IProductCategoryRepository _productCategoryRepository;

        public UnitOfWork(ProductHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository userRepository => _userRepository ??= new UserRepository(_dbContext);
        public IProductRepository productRepository => _productRepository ??= new ProductRepository(_dbContext);
        public ICategoryRepository categoryRepository => _categoryRepository ??= new CategoryRepository(_dbContext);
        public IProductCategoryRepository productCategoryRepository => _productCategoryRepository ??= new ProductCategoryRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
