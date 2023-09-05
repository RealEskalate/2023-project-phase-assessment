using Application.Contracts.Persistance;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence.Persistance.Repository;

namespace Persistence.Repositories;

public class ProductRepository :   GenericRepository<Product>, IProductRepository{
    
    private readonly ProductHubDbContext _context;

    public ProductRepository(ProductHubDbContext context) : base(context){
        _context = context;
    }

    public async Task<List<Product>> Search(string name, int pageNumber = 0, int pageSize = 10){
        return await _context.Products
            .Where(x => x.Name.Contains(name))
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    
}