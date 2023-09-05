using Application.DTOs.Category;
using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetCategories;
using Application.Features.Category.Queries.GetCategoryDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryController: ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // Get all categories
    [HttpGet]
    public async Task<ActionResult<List<CategoryDetailsDto>>> Get()
    {
        var categories = await _mediator.Send(new GetCategoryListQuery());
        return Ok(categories);
    }
    
    // Get category by id
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDetailsDto>> Get(Guid id)
    {
        var category = await _mediator.Send(new GetCategoryDetailQuery(){Id = id});
        return Ok(category);
    }
    
    // Create category
    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create(CreateCategoryDto category)
    {
        var result = await _mediator.Send(new CreateCategoryCommand(){Category = category});
        return Ok(result);
    }
    
    // update Category
    [HttpPut("update")]
    public async Task<ActionResult> Update(CategoryDetailsDto category)
    {
        await _mediator.Send(new UpdateCategoryCommand(){Category = category});
        return NoContent();
    }
    
    // delete Category
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteCategoryCommand(){Id = id});
        return NoContent();
    }
}