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
                Id = new Guid(),
                Name = "Product1",
                Price = 10,
                Stock = 100
            },
            new Product
            {
                Id = new Guid(),
                Name = "Product2",
                Price = 20,
                Stock = 50
            },
        };

        var productRepository = new Mock<IProductRepository>();

        productRepository
            .Setup(repo => repo.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Guid id) => products.FirstOrDefault(p => p.Id == id));

        productRepository.Setup(repo => repo.GetAsync()).ReturnsAsync(products);

        productRepository
            .Setup(repo => repo.AddAsync(It.IsAny<Product>()))
            .ReturnsAsync(
                (Product product) =>
                {
                    product.Id = new Guid();
                    products.Add(product);
                    return product;
                }
            );

        productRepository
            .Setup(repo => repo.UpdateAsync(It.IsAny<Guid>(), It.IsAny<Product>()))
            .Callback(
                (Guid id, Product product) =>
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
            .Setup(repo => repo.DeleteAsync(It.IsAny<Guid>()))
            .Callback(
                (Guid id) =>
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
