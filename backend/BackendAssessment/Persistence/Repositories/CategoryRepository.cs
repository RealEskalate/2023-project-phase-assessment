using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Persistence.Repositories;

public class CategoryRepository :  GenericRepository<Category>, ICategoryRepository
{
    private readonly BackendAssessmentDbContext _context;
    public CategoryRepository(BackendAssessmentDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
    
    
    
}