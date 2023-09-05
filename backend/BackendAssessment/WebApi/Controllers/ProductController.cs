using Application.DTOs.Product;
using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Commands.DeleteProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Features.Product.Queries.GetAllProducts;
using Application.Features.Product.Queries.GetSingleProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        var command = new CreateProductCommand()
        {
            CreateProductDto = createProductDto
        };
        
        var product = await _mediator.Send(command);
        
        return CreatedAtAction(null, product);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProduct(Guid productId, ProductReqResDto productReqResDto)
    {
        var command = new UpdateProductCommand()
        {
            ProductId = productId,
            ProductReqResDto = productReqResDto
        };
        
        var product = await _mediator.Send(command);
        
        return Ok(product);
    }
    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        var command = new DeleteProductCommand()
        {
            ProductId = productId
        };
        
        var product = await _mediator.Send(command);
        
        return Ok(product);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProduct(Guid productId)
    {
        var command = new GetSingleProductCommand()
        {
            ProductId = productId
        };
        
        var product = await _mediator.Send(command);
        
        return Ok(product);
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllProducts()
    {
        var command = new GetAllProductsCommand();
        
        var products = await _mediator.Send(command);
        
        return Ok(products);
    }
}