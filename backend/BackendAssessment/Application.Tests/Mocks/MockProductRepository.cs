using Application.Contracts;
using Domain.Entities;
using Moq;

namespace Application.Tests.Mocks;
public class MockProductReposiotry{
      public static Mock<IProductRepository> GetPostRepository(){

        User user = new()
        {
            Id = 1,
            Username = "mockuser",
            PasswordHash = "mockpassword",
            Email = "mockemail@mock.com" };
        var products = new List<Product>{
            new() {
                Id = 1,
                Name = "Product 1",
                Description = "Product 1 Description",
                Price = 100,
                CategoryId = 1,
                Category = new Category{
                    Id = 1,
                    Name = "Category 1",
                    Description = "Category 1 Description"
                },
                UserId = 1,
                IsAvailable = true,
            },
            new() {
                Id = 2,
                Name = "Product 2",
                Description = "Product 2 Description",
                Price = 200,
                CategoryId = 2,
                Category = new Category{
                    Id = 2,
                    Name = "Category 2",
                    Description = "Category 2 Description"
                },
                UserId = 1,
                IsAvailable = true,
            },
            new() {
                Id = 3,
                Name = "Product 3",
                Description = "Product 3 Description",
                Price = 300,
                CategoryId = 3,
                Category = new Category{
                    Id = 3,
                    Name = "Category 3",
                    Description = "Category 3 Description"
                },
                UserId = 1,
                IsAvailable = true,
            },
        };

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);
        mockProductRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => products.Find(product => product.Id == id));
        mockProductRepository.Setup(repo => repo.AddAsync(It.IsAny<Product>()))
            .Callback((Product product) => products.Add(product));
        mockProductRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Product>()))
            .Callback((Product product) => {
                var index = products.FindIndex(x => x.Id == product.Id);
                products[index] = product;
            });
        mockProductRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Product>()))
            .Callback((Product product) => products.Remove(product));

        return mockProductRepository;
      }
}