using System.Security.Claims;
using Application.Dtos.CategoryDtos;
using Application.Dtos.ProductDto;
using Application.Features.Category.Requests.Commands;
using Application.Features.Product.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Middleware;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("Add")]
    public async Task<IActionResult> AddCategory([FromBody]CreateCategoryDto createCategory){
        var UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
        
            
        var command = new CreateCategoryCommand() {CreateCategory = createCategory, UserId = UserId};
        var categoryId = await _mediator.Send(command);
        return ResponseHandler<int?>.HandleResponse(categoryId, 201);
    }
    [HttpPut("{categoryId:int}")]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategory, int categoryId){
        
        updateCategory.Id = categoryId;
        var command = new UpdateCategoryCommand() { updateCategory = updateCategory, UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1")};
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit?>.HandleResponse(result, 204);
    }

}