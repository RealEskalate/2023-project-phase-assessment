using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;
using BackendAssessment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace BackendAssessment.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AssessmentDbContext context) : base(context)
    {
    }

    
}