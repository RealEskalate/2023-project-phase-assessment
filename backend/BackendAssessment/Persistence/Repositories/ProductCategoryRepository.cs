using Application.Contracts.Persistance;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Persistence.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ProductHubDbContext _dbContext;

        public ProductCategoryRepository(ProductHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByProductId(int productId)
        {
            return await _dbContext.ProductCategories
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesByCategoryId(int categoryId)
        {
            return await _dbContext.ProductCategories
                .Where(pc => pc.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<ProductCategory> AddProductToCategory(int productId, int categoryId)
        {
            var productCategory = new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            };

            await _dbContext.ProductCategories.AddAsync(productCategory);
            await _dbContext.SaveChangesAsync();

            return productCategory;
        }

        public async Task<bool> RemoveProductFromCategory(int productId, int categoryId)
        {
            var productCategory = await _dbContext.ProductCategories
                .FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId);

            if (productCategory == null)
            {
                return false;
            }

            _dbContext.ProductCategories.Remove(productCategory);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
