using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Persistence.Repositories;

public class CategoryRepository :  GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(BackendAssessmentDbContext dbContext) : base(dbContext)
    {
    }
}