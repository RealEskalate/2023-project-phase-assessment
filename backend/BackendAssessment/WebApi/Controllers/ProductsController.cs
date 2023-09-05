using Application.Features.Products.Dtos;
using Application.Features.Products.Queries.Commands;
using Application.Features.Products.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var request = new GetAllProductsRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var request = new GetProductRequest { ProductId = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductDto request)
    {
        var createRequest = new CreateProductCommand { UserId = 1, CreateProductDto = request };
        var response = await _mediator.Send(createRequest);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ProductDto request)
    {
        var updateRequest = new UpdateProductCommand { UserId = 1, UpdateProductDto = request };
        var response = await _mediator.Send(updateRequest);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var request = new DeleteProductCommand { UserId = 1, ProductId = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
