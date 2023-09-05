using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    
    
    private readonly ProductHubDbContext _dbContext;
    private IUserRepository _userRepository;
    private IProductRepository _productRepository;
    private ICategoryRepository _categoryRepository;
    private IBookingRepository _bookingRepository;

    public UnitOfWork(ProductHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);
    public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_dbContext);
    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_dbContext);
    public IBookingRepository BookingRepository => _bookingRepository ??= new BookingRepository(_dbContext);

    public async Task<int> Save()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Detach(BaseEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Detached;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}