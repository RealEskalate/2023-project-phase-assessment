using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductHubDbContext _dbContext;

        public CategoryRepository(ProductHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _dbContext.Categories.FindAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task CreateCategoryAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
