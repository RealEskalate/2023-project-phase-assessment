using Application.DTOs.Category;
using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Category.Queries.GetSingleCategory;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Service;

namespace WebApi.Controllers;

public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryResponseDto>> Get(int id)
    {
        return await _mediator.Send(new GetSingleCategoryRequest
        {
            Id = id
        });
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<List<CategoryResponseDto>>> GetAllCategories()
    {
        var products = await _mediator.Send(new GetAllCategoriesRequest());
        return products;
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<CategoryResponseDto>> UpdateCategory(int id, CategoryRequestDto productRequestDto)
    {
        await AuthHelper.OnlyAdminUser(User);
        
        return await _mediator.Send(new UpdateCategoryCommand
        {
            CategoryId = id,
            CategoryDto = productRequestDto
        });
    }
    
    
    [HttpPost("create")]
    public async Task<ActionResult<CategoryResponseDto>> CreateCategory(CategoryRequestDto productRequestDto)
    {
        await AuthHelper.OnlyAdminUser(User);
        
        return await _mediator.Send(new CreateCategoryCommand
        {
            CategoryDto = productRequestDto
        });
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Unit>> DeleteCategory(int id)
    {
        await AuthHelper.OnlyAdminUser(User);
        
        return await _mediator.Send(new DeleteCategoryCommand
        {
            CategoryId = id
        });
    }
}