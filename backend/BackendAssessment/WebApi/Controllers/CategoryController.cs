using Application.Dto.Category;
using Application.Features.Category.Requests.Commands;
using Application.Features.Category.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CategoryDto>>> GetAllCategories()
    {
        var result = await _mediator.Send(new GetCategoriesRequest());
        return Ok(result);
    }

    [HttpGet("{categoryId:int}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(int categoryId)
    {
        var result = await _mediator.Send(new GetCategoryByIdRequest(categoryId)); 
        if (result == null) return NotFound("category not found");
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CreateCategoryDto createCategory)
    {
        var result = await _mediator.Send(new CreateCategoryRequest(createCategory));
        return CreatedAtAction(nameof(GetCategoryById), new {categoryId = result.Id}, result);
    }
    
    [HttpPut]
    public async Task<ActionResult<Unit>> UpdateCategory([FromBody] CategoryDto updateCategory)
    {
        var result = await _mediator.Send(new UpdateCategoryRequest(updateCategory));
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult<Unit>> DeleteCategory(int categoryId)
    {
        var result = await _mediator.Send(new DeleteCategoryRequest(categoryId));
        return NoContent();
    }
}