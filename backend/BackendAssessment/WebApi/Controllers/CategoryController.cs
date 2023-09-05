using Application.DTOs.Category;
using Application.Features.Categories.Requests.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Controller]
[Route("api/[controller]")]

public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
    {
        var request = new CreateCategoryCommand() { CategoryDto = categoryDto };
        var response = await _mediator.Send(request);
        
        return ResponseHandler<Category>.HandleResponse(response, 201);
    }
}