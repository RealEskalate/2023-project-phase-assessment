using Application.Features.Categorie.Queries.Requests;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Queries.Commands;
using Application.Features.Categories.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;

    public CategoriesController(IMediator mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var request = new GetAllCategoriesRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var request = new GetCategoryRequest { CategoryId = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] CategoryDto request)
    {
        var userId = _userService.GetUserId();
        var createRequest = new CreateCategoryCommand
        {
            UserId = userId,
            CreateCategoryDto = request
        };
        var response = await _mediator.Send(createRequest);
        return Ok(response);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Put([FromBody] UpsertCategoryDto request)
    {
        var userId = _userService.GetUserId();
        var updateRequest = new UpdateCategoryCommand
        {
            UserId = userId,
            UpdateCategoryDto = request
        };
        var response = await _mediator.Send(updateRequest);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = _userService.GetUserId();
        var request = new DeleteCategoryCommand { UserId = userId, CategoryId = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
