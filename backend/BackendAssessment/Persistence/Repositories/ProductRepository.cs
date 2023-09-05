using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;
namespace BackendAssessment.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(BackendAssessmentDbContext dbContext) : base(dbContext)
    {
    }
}