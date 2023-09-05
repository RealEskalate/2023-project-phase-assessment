using Application.DTOs.Category;
using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Category.Queries.GetSingleCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryReqResDto categoryReqResDto)
    {
        var command = new CreateCategoryCommand()
        {
            CategoryReqResDto = categoryReqResDto
        };
        
        var category = await _mediator.Send(command);
        
        return CreatedAtAction(null, category);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateCategory(Guid categoryId, CategoryReqResDto categoryReqResDto)
    {
        var command = new UpdateCategoryCommand()
        {
            CategoryId = categoryId,
            CategoryReqResDto = categoryReqResDto
        };
        
        var category = await _mediator.Send(command);
        
        return Ok(category);
    }
    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        var command = new DeleteCategoryCommand()
        {
            CategoryId = categoryId
        };
        
        var category = await _mediator.Send(command);
        
        return Ok(category);
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCategories()
    {
        var command = new GetAllCategoriesCommand();
        
        var categories = await _mediator.Send(command);
        
        return Ok(categories);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategory(Guid categoryId)
    {
        var command = new GetSingleCategoryCommand()
        {
            CategoryId = categoryId
        };
        
        var category = await _mediator.Send(command);
        
        return Ok(category);
    }
}