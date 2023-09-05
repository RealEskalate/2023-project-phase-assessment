using Application.Contracts.Persistance;
using Persistence.Repositories;

namespace Persistence.Persistance.Repository;

public class UnitOfWork : IUnitOfWork{
    private readonly ProductHubDbContext _context;
    private IProductRepository _productRepository;
    private ICategoryRepository _categoryRepository;


    public UnitOfWork(ProductHubDbContext context){
        _context = context;
    }

    public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);
    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);


    public void Dispose(){
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<int> Save(){
        return await _context.SaveChangesAsync();
    }
}