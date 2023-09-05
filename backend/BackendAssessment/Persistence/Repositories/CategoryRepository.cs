using Application.Contracts.Persistance;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence.Persistance.Repository;

namespace Persistence.Repositories;

public class CategoryRepository :   GenericRepository<Category>, ICategoryRepository{
    
    private readonly ProductHubDbContext _context;

    public CategoryRepository(ProductHubDbContext context) : base(context){
        _context = context;
    }

    public async Task<List<Category>> Search(string name, int pageNumber = 0, int pageSize = 10){
        return await _context.Categories
            .Where(x => x.Name.Contains(name))
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    
}