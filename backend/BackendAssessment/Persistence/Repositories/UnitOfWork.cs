using Application.Contracts.Persistence;

namespace Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductHubDbContext _dbContext;
    
    private IProductRepository? _productRepository;
    private ICategoryRepository? _categoryRepository;


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
    
    public ICategoryRepository CategoryRepository =>
        _categoryRepository ??= new CategoryRepository(_dbContext);



    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync();
    }
}