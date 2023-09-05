using Application.Contracts.Common;
using Domain.Entities;

namespace Application.Contracts;

public interface IProductRepository : IGenericRepository<ProductEntity>
{
    
}