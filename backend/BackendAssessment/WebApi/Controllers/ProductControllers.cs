using Application.DTO.Product;
using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Commands.DeleteUser;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Features.Product.Queries.GetAllProducts;
using Application.Features.Product.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("All")]
    public async Task<ActionResult<List<ProductResponseDto>>> GetAll()
    {
        var prods = await _mediator.Send(new GetAllProductQuery());
        return Ok(prods);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponseDto>> GetById(int id)
    {
        var prod = await _mediator.Send(new GetProductByIdQuery() {ProdId = id});
        return Ok(prod);
    }
    
    [HttpPost()]
    public async Task<ActionResult<ProductResponseDto>> Create([FromBody] CreateProdDto prod)
    {
        var newProd = await _mediator.Send(new CreateProductCommand() {CreateProductDto = prod});
        return CreatedAtAction(nameof(GetById), new{Id = newProd.Id}, newProd);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<ProductResponseDto>> Update(int id, [FromBody] CreateProdDto prod)
    {
        var updatedProd = await _mediator.Send(new UpdateProductCommand() {ProdId = id, CreateProdDto = prod});
        return Ok(updatedProd);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProductCommand() {ProdId = id});
        return NoContent();
    }
}