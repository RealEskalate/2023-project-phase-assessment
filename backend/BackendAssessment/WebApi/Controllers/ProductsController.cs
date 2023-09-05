using Application.DTOs.Product;
using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Commands.DeleteProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Features.Product.Queries.GetAllProducts;
using Application.Features.Product.Queries.GetSingleProduct;
using Application.Features.Product.Queries.GetSingleProductWithOwner;
using Application.Features.Product.Queries.SearchProductsByNameAndDesc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Service;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductResponseDto>> Get(int id)
    {
        return await _mediator.Send(new GetSingleProductRequest
        {
            Id = id
        });
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<List<ProductResponseDto>>> GetAllProducts()
    {
        var products = await _mediator.Send(new GetAllProductsRequest());
        return products;
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProductResponseDto>> UpdateProduct(int id, UpdateProductDto productRequestDto)
    {
        var product = await _mediator.Send(new GetSingleProductWithOwnerRequest() { ProductId = id });
        await AuthHelper.CheckUserById(User, product.ProductOwner.Id);
        
        
        return await _mediator.Send(new UpdateProductCommand
        {
            ProductId = id,
            ProductDto = productRequestDto
        });
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Unit>> DeleteProduct(int id)
    {
        var product = await _mediator.Send(new GetSingleProductWithOwnerRequest() { ProductId = id });
        await AuthHelper.CheckUserById(User, product.ProductOwner.Id);
        
        return await _mediator.Send(new DeleteProductCommand
        {
            ProductId = id
        });
    }
    
    [HttpPost]
    public async Task<ActionResult<ProductResponseDto>> CreateProduct(int categoryId, ProductRequestDto productRequestDto)
    {
        return await _mediator.Send(new CreateProductCommand
        {
            CategoryId = categoryId,
            ProductOwnerId = await AuthHelper.GetUserId(User),
            ProductDto = productRequestDto
        });
    }
    
    [HttpGet("search")]
    public async Task<ActionResult<List<ProductResponseDto>>> SearchProductsByName(string name)
    {
        var products = await _mediator.Send(new SearchProductsByNameAndDescQuery()
        {
            Name = name
        });
        return products;
    }
}