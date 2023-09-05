using ProductHub.Application.Contracts.Persistence;

namespace ProductHub.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductHubDbContext _dbContext;

    private IUserRepository? _userRepository;
    private IProductRepository? _productRepository;
    private ICategoryRepository? _categoryRepository;

    public UnitOfWork(ProductHubDbContext dbContext) => _dbContext = dbContext;

    public IUserRepository UserRepository
    {
        get => _userRepository ??= new UserRepository(_dbContext);
    }

    public IProductRepository ProductRepository
    {
        get => _productRepository ??= new ProductRepository(_dbContext);
    }

    public ICategoryRepository CategoryRepository
    {
        get => _categoryRepository ??= new CategoryRepository(_dbContext);
    }


    public async Task<int> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
