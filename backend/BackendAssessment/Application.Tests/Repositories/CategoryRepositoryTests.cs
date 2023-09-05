using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Application.Test.Repositories
{
    public class CategoryRepositoryTests
    {
        [Fact]
        public async Task GetCategoryAsync_Returns_Category_When_Exists()
        {
            // Arrange
            var categoryId = 1;
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Category 1", Description = "Description 1" },
                new Category { CategoryId = 2, Name = "Category 2", Description = "Description 2" }
            }.AsQueryable();

            var mockContext = new Mock<ProductHubDbContext>();
            mockContext.Setup(c => c.Categories).ReturnsDbSet(categories);

            var categoryRepository = new CategoryRepository(mockContext.Object);

            // Act
            var category = await categoryRepository.GetCategoryAsync(categoryId);

            // Assert
            Assert.NotNull(category);
            Assert.Equal(categoryId, category.CategoryId);
        }


    }
}
