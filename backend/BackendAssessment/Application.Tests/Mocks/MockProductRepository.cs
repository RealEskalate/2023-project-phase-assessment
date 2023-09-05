using Application.Contracts.Persistence;
using Domain.Entities;
using Moq;

public class MockProductRepository
{
    public static Mock<IProductRepository> GetMockProductRepository()
    {
        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Product1",
                Price = 10,
                Stock = 100
            },
            new Product
            {
                Id = 2,
                Name = "Product2",
                Price = 20,
                Stock = 50
            },
        };

        var productRepository = new Mock<IProductRepository>();

        productRepository
            .Setup(repo => repo.GetAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => products.FirstOrDefault(p => p.Id == id));

        productRepository.Setup(repo => repo.GetAsync()).ReturnsAsync(products);

        productRepository
            .Setup(repo => repo.AddAsync(It.IsAny<Product>()))
            .ReturnsAsync(
                (Product product) =>
                {
                    product.Id = products.Count + 1;
                    products.Add(product);
                    return product;
                }
            );

        productRepository
            .Setup(repo => repo.UpdateAsync(It.IsAny<int>(), It.IsAny<Product>()))
            .Callback(
                (int id, Product product) =>
                {
                    var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
                    if (existingProduct != null)
                    {
                        existingProduct.Name = product.Name;
                        existingProduct.Price = product.Price;
                        existingProduct.Stock = product.Stock;
                    }
                }
            );

        productRepository
            .Setup(repo => repo.DeleteAsync(It.IsAny<int>()))
            .Callback(
                (int id) =>
                {
                    var product = products.FirstOrDefault(p => p.Id == id);
                    if (product != null)
                    {
                        products.Remove(product);
                    }
                }
            );

        return productRepository;
    }
}
