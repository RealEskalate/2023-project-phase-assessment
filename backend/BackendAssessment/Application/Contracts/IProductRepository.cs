using Application.Contracts.Common;
using Domain.Entites;

namespace Application.Contracts;

public interface IProductRepository : IGenericRepository<ProductEntity>
{
    public Task<ProductEntity?> GetSingleProductWithOwner(int id);
}