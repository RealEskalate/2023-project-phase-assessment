using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendAssessment.Application.Features.Category.Commands.Requests;
using BackendAssessment.Application.Features.Category.DTO;
using MediatR;

namespace BackendAssessment.API.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
    {

        var result = await _mediator.Send(new CreateCategoryCommand() { createCategoryDto = createCategoryDto
    });

    if (result.IsSuccess)
    {
        return Ok(Response);
    }

        return BadRequest(result);
    }
}