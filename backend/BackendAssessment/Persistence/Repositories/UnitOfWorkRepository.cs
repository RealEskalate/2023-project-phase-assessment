using BackendAssessment.Application.Contracts.Persistence;

namespace BackendAssessment.Persistence.Repositories;

public class UnitOfWorkRepository : IUnitOfWork
{
    private readonly BackendAssessmentDbContext _dbContext;
    private IUserRepository? _userRepository;
    private IProductRepository? _productRepository;
    private ICategoryRepository? _categoryRepository;

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

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
}