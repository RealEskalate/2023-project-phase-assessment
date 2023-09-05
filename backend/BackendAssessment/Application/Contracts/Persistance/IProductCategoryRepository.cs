using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistance
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetProductCategoriesByProductId(int productId);
        Task<IEnumerable<ProductCategory>> GetProductCategoriesByCategoryId(int categoryId);
        Task<ProductCategory> AddProductToCategory(int productId, int categoryId);
        Task<bool> RemoveProductFromCategory(int productId, int categoryId);
    }
}
