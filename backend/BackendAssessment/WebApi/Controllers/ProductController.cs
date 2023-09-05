using Application.Dtos.Product;
using Application.Features.Product.Commands.Create;
using Application.Features.Product.Commands.Delete;
using Application.Features.Product.Commands.Update;
using Application.Features.Product.Queries.GetAll;
using Application.Features.Product.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    [Route("GetSingleProduct/{Id}")]
    public async Task<ActionResult<ProductResponseDto>> GetSingleProduct(Guid Id)
    {
        var product = await _mediator.Send(new GetSingleProductRequest{ProductId = Id});
        return Ok(product);
    }

    [HttpGet()]
    [Route("GetAllProduct")]
    public async Task<ActionResult<IReadOnlyList<ProductResponseDto>>> GetAllProduct(Guid Id)
    {
        var products = await _mediator.Send(new GetAllProductRequest());
        return Ok(products);
    }
   
    [HttpPost()]
    [Route("CreateProduct")]
    public async Task<ActionResult<ProductResponseDto>> CreateProduct(ProductRequestDto new_product)
    { 
        var product = await _mediator.Send(new CreateProductCommand{NewProduct = new_product});

        return Ok(product);
    }

    [HttpPut()]
    [Route("UpdateProduct/{Id}")]
    public async Task<ActionResult<ProductResponseDto>> UpdateProduct(Guid Id, ProductRequestDto update_product)
    { 
        var product = await _mediator.Send(new UpdateProductCommand
        {
            ProductId = Id,
            UpdateProduct = update_product
        });

        return Ok(product);
    }
    
    [HttpDelete()]
    [Route("DeleteProduct/{Id}")]
    public async Task<ActionResult> DeleteProduct(Guid Id)
    { 
        await _mediator.Send(new DeleteProductCommand{ProductId = Id});

        return NoContent();
    }
}
