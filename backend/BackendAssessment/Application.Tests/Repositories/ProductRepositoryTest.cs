using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Application.Test.Repositories
{
    public class ProductRepositoryTests
    {
        [Fact]
        public async Task GetProductAsync_Returns_Product_When_Exists()
        {
            // Arrange
            var productId = 1;
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Product 1",
                    Description = "Description 1",
                    Pricing = 10.0M,
                    Availability = 5,
                    UserId = 1,
                    CategoryId = 1,
                    User = new User { UserId = 1, Username = "User 1" },
                    Category = new Category { CategoryId = 1, Name = "Category 1" }
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Product 2",
                    Description = "Description 2",
                    Pricing = 15.0M,
                    Availability = 3,
                    UserId = 2,
                    CategoryId = 2,
                    User = new User { UserId = 2, Username = "User 2" },
                    Category = new Category { CategoryId = 2, Name = "Category 2" }
                }
            }.AsQueryable();

            var mockContext = new Mock<ProductHubDbContext>();
            mockContext.Setup(c => c.Products).ReturnsDbSet(products);

            var productRepository = new ProductRepository(mockContext.Object);

            // Act
            var product = await productRepository.GetProductAsync(productId);

            // Assert
            Assert.NotNull(product);
            Assert.Equal(productId, product.ProductId);
            Assert.Equal("Product 1", product.Name);
            Assert.Equal("Description 1", product.Description);
            Assert.Equal(10.0M, product.Pricing);
            Assert.Equal(5, product.Availability);
            Assert.Equal(1, product.UserId);
            Assert.NotNull(product.User);
            Assert.Equal(1, product.CategoryId);
            Assert.NotNull(product.Category);
        }


    }
}
