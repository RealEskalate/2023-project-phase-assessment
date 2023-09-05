using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Product;
using Domain.Entites;

namespace Application.Contracts.Persisitence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IReadOnlyList<Product>> SearchProductsByName(string name, int pageIndex, int pageSize);
        Task<IReadOnlyList<Product>> FilterProductsByCatagoryId(Guid catagoryId, int pageIndex, int pageSize);
    }
}