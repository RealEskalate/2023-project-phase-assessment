using Application.Contracts.Persistence;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductHubDbContext _dbContext;
    private IProductRepository _productRepository;
    private IUserRepository _userRepository;
    private ICategoryRepository _categoryRepository;
    private IBookingRepository _bookingRepository;

    public UnitOfWork(ProductHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_dbContext);

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);

    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_dbContext);

    public IBookingRepository BookingRepository => _bookingRepository ??= new BookingRepository(_dbContext);

    public void Dispose()
    {
        _dbContext.Dispose();
    }
    
    public async Task<int> Save(){
        return await _dbContext.SaveChangesAsync();
    }
}