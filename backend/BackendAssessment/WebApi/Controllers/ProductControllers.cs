using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Application.Features.Products.Requests.Commands;
using ProductHub.Application.Features.Products.Requests.Queries;

using ProductHub.WebApi.Services.Interfaces;

namespace ProductHub.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductControllers : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;
    public ProductControllers(IMediator mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }
    // Create a new notification
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto productCreateDto)
    {
        var command = new CreateProductCommand {ProductCreateDto = productCreateDto};
        var response = await _mediator.Send(command);

        if(response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }

    // delete a notification
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        int authUserId = _userService.GetUserId();
        var command = new DeleteProductCommand {ProductId = id};
        var response = await _mediator.Send(command);

        if (response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }

    // Get all notifications for a user
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllProductsForUser(int userId)
    {
        var products = new GetProductListRequest {UserId = userId};
        var response = await _mediator.Send(products);

        if (response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }

    // Get details of a specific notification
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetail(int id)
    {
        var ProductDetial = new GetProductDetailRequest {Id = id};
        var response = await _mediator.Send(ProductDetial);

        if (response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }
}

