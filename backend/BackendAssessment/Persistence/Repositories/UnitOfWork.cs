using Application.Contracts;
using Persistence.Configurations;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AssessmentDbContext _dbContext;
    
    private IProductRepository? _productRepository;
    private ICategoryRepository? _categoryRepository;
    
    public UnitOfWork(AssessmentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_dbContext);
    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_dbContext);
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
    
}