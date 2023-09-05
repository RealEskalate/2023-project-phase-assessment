using Backend.Application.DTOs.Product;
using Backend.Application.Persistence.Contracts;
using Backend.Domain.Entities;
using ErrorOr;

namespace Backend.Infrastructure.Persistence.Repositories.ProductRepo;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products;
    private readonly List<ProductCategory> _productCategories;
    public Task<List<Product>> GetProductByBrand(string brand)
    {
        var product = new List<Product>();
        foreach (var p in _products)
        {
            if (p.Brand == brand)
            {
                product.Add(p);
            }
        }

        return Task.FromResult(product);
    }

    public Task<List<Product>> GetProductByCategory(string category)
    {
        var product = new List<Product>();
        foreach(var pc in _productCategories)
        {
            if (pc.Category.Name == category)
            {
                product.Add(pc.Product);
            }
        }

        return Task.FromResult(product);
    }

    public Task<Product> GetProductById(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task<List<Product>> GetProductByName(string name)
    {
        var product = new List<Product>();
        foreach (var p in _products)
        {
            if (p.Name == name)
            {
                product.Add(p);
            }
        }

        return Task.FromResult(product);
    }

    public Task<List<Product>> GetProductByPrice(decimal price)
    {
        var product = new List<Product>();
        foreach (var p in _products)
        {
            if (p.Price == price)
            {
                product.Add(p);
            }
        }

        return Task.FromResult(product);
    }

    public Task<Product> PostProduct(Product product)
    {
        _products.Add(product);
        _productCategories.Add(new ProductCategory
        {
            Product = product,
            Category = product.Categories!.First()
        });
        return Task.FromResult(product);
    }
}