using Application.Features.Products.Dtos;
using Application.Features.Products.Queries.Commands;
using Application.Features.Products.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;

    public ProductsController(IMediator mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
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
    [Authorize]
    public async Task<IActionResult> Post([FromBody] ProductDto request)
    {
        var userId = _userService.GetUserId();
        var createRequest = new CreateProductCommand
        {
            UserId = userId,
            CreateProductDto = request
        };
        var response = await _mediator.Send(createRequest);
        return Ok(response);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Put([FromBody] ProductDto request)
    {
        var userId = _userService.GetUserId();

        var updateRequest = new UpdateProductCommand
        {
            UserId = userId,
            UpdateProductDto = request
        };
        var response = await _mediator.Send(updateRequest);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = _userService.GetUserId();
        var request = new DeleteProductCommand { UserId = userId, ProductId = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
