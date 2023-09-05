using Application.DTOs.Product;
using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Commands.DeleteProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Features.Product.Queries.GetProductDetail;
using Application.Features.Product.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;


    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // Get all products
    [HttpGet]
    public async Task<ActionResult<List<ProductDetailsDto>>> Get()
    {
        var products = await _mediator.Send(new GetProductListQuery());
        return Ok(products);
    }
    
    // Get Product by id
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailsDto>> Get(Guid id)
    {
        var product = await _mediator.Send(new GetProductDetailQuery(){Id = id});
        return Ok(product);
    }
    
    // Create Product
    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create(CreateProductDto product)
    {
        var result = await _mediator.Send(new CreateProductCommand(){Product = product});
        return Ok(result);
    }
    
    // update Product
    [HttpPut("update")]
    public async Task<ActionResult> Update(ProductDetailsDto product)
    {
        await _mediator.Send(new UpdateProductCommand(){Product = product});
        return NoContent();
    }
    
    // delete Product
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteProductCommand(){Id = id});
        return NoContent();
    }
    
}