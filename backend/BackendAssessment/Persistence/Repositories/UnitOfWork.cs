using Application.Contracts.Persistence;
using BackendAssessment.Application.Contracts.Persistence;
using Persistence;
using Persistence.Repositories;

namespace BackendAssessment.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AssessmentDbContext _context;
    private IUserRepository _userRepository;
    private IProductRepository _productRepository;
    private ICategoryRepository _categoryRepository;
    private IBookingRepository _bookingRepository;
    

    public UnitOfWork(AssessmentDbContext context)
    {
        _context = context;
    }

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);
    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);
    public IBookingRepository BookingRepositoryRepository => _bookingRepository ??= new BookingRepository(_context);
    

    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}