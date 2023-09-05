
using System.Security.Claims;
using BackendAssessment.Application.DTOs.CategoryDtos;
using BackendAssessment.Application.Features.Categories.Handlers.Commands;
using BackendAssessment.Application.Features.Categories.Requests.Commands;
using BackendAssessment.Application.Features.Categories.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Categorys = await _mediator.Send(new GetAllCategoriesRequest());
        return Ok(Categorys);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var request = new GetCategoryRequest() { Id = id };
        var Category = await _mediator.Send(request);
        return Ok(Category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto Category)
    {
        // Add user Id to the dto from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        Category.UserId = userId;
        
        var request = new CreateCategoryRequest() { CategoryDto = Category };
        var createdCategory = await _mediator.Send(request);
        return Ok(createdCategory);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(CategoryDto Category)
    {
        // Add user Id to the dto from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        Category.UserId = userId;
        
        var request = new UpdateCategoryRequest() { CategoryDto = Category };
        var updatedCategory = await _mediator.Send(request);
        return Ok(updatedCategory);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var request = new DeleteCategoryRequest() { Id = id };
        await _mediator.Send(request);
        return NoContent();
    }
}