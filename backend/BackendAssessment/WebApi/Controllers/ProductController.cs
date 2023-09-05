using Application.Dto.Product;
using Application.Features.Product.Requests.Command;
using Application.Features.Product.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ActionResult<List<ProductDto>>> GetProductsByCategoryId(int categoryId)
    {
        var result = await _mediator.Send(new GetProductsByCategoryIdRequest(categoryId));
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetProductsRequest());
        return Ok(result);
    }

    [HttpGet("{productId:int}")]
    public async Task<ActionResult<ProductDto>> GetProductById(int productId)
    {
        var result = await _mediator.Send(new GetProductByIdRequest(productId));

        if (result == null) return NotFound("product not found");
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> CreateProduct([FromBody] ProductCreationDto createProduct)
    {
        var result = await _mediator.Send(new CreateProductRequest(createProduct));
        return CreatedAtAction(nameof(GetProductById), new {productId = result.Id}, result);
    }

    [HttpPut]
    public async Task<ActionResult<Unit>> UpdateProduct([FromBody] ProductDto updateProduct)
    {
        var result = await _mediator.Send(new UpdateProductRequest(updateProduct));
        return NoContent();
    }

    [HttpDelete("{productId:int}")]
    public async Task<ActionResult<Unit>> DeleteProduct(int productId)
    {
        var result = await _mediator.Send(new DeleteProductRequest(productId));
        return NoContent();
    }




}