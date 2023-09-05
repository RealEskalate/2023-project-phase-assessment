using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;
using BackendAssessment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace BackendAssessment.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AssessmentDbContext context) : base(context)
    {
    }

    public Task<List<Product>> GetByCategory(string categoryName)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetByPosterId(int posterId)
    {
        throw new NotImplementedException();
    }
}