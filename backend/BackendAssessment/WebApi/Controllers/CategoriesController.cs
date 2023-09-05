using Application.Features.Categorie.Queries.Requests;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Queries.Commands;
using Application.Features.Categories.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var request = new GetAllCategoriesRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var request = new GetCategoryRequest { CategoryId = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoryDto request)
    {
        var createRequest = new CreateCategoryCommand { UserId = 1, CreateCategoryDto = request };
        var response = await _mediator.Send(createRequest);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CategoryDto request)
    {
        var updateRequest = new UpdateCategoryCommand { UserId = 1, UpdateCategoryDto = request };
        var response = await _mediator.Send(updateRequest);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var request = new DeleteCategoryCommand { UserId = 1, CategoryId = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
