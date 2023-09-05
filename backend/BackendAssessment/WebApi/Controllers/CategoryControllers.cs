using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductHub.Application.DTOs.CategoryDtos;
using ProductHub.Application.Features.Categories.Requests.Commands;
using ProductHub.Application.Features.Categories.Requests.Queries;

using ProductHub.WebApi.Services.Interfaces;

namespace ProductHub.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryControllers : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;
    public CategoryControllers(IMediator mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }
    // Create a new category
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto categoryCreateDto)
    {
        var command = new CreateCategoryCommand {CategoryCreateDto = categoryCreateDto};
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
    public async Task<IActionResult> DeleteCategory(int id)
    {
        int authUserId = _userService.GetUserId();
        var command = new DeleteCategoryCommand {CategoryId = id};
        var response = await _mediator.Send(command);

        if (response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }

    // Get all categories
    [HttpGet("categories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = new GetAllCategoriesRequest {};
        var response = await _mediator.Send(categories);

        if (response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }

    // Get details of a specific category
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryDetail(int id)
    {
        var CategoryDetail = new GetCategoryDetailRequest {CategoryId = id};
        var response = await _mediator.Send(CategoryDetail);

        if (response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }
}

