using Application.Dtos.Category;
using Application.Features.Category.Commands.Create;
using Application.Features.Category.Commands.Delete;
using Application.Features.Category.Commands.Update;
using Application.Features.Category.Queries.GetAll;
using Application.Features.Category.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    [Route("GetSingleCategory/{Id}")]
    public async Task<ActionResult<CategoryResponseDto>> GetSingleCategory(Guid Id)
    {
        var category = await _mediator.Send(new GetSingleCategoryRequest{CategoryId = Id});
        return Ok(category);
    }

    [HttpGet()]
    [Route("GetAllCategory")]
    public async Task<ActionResult<IReadOnlyList<CategoryResponseDto>>> GetAllCategory(Guid Id)
    {
        var categories = await _mediator.Send(new GetAllCategoryRequest());
        return Ok(categories);
    }
   
    [HttpPost()]
    [Route("CreateCategory")]
    public async Task<ActionResult<CategoryResponseDto>> CreateCategory(CategoryRequestDto new_category)
    { 
        var category = await _mediator.Send(new CreateCategoryCommand{NewCategory = new_category});

        return Ok(category);
    }

    [HttpPut()]
    [Route("UpdateCategory/{Id}")]
    public async Task<ActionResult<CategoryResponseDto>> UpdateCategory(Guid Id, CategoryRequestDto update_category)
    { 
        var category = await _mediator.Send(new UpdateCategoryCommand
        {
            CategoryId = Id,
            UpdateCategory = update_category
        });

        return Ok(category);
    }
    
    [HttpDelete()]
    [Route("DeleteCategory/{Id}")]
    public async Task<ActionResult> DeleteCategory(Guid Id)
    { 
        await _mediator.Send(new DeleteCategoryCommand{CategoryId = Id});

        return NoContent();
    }
}
