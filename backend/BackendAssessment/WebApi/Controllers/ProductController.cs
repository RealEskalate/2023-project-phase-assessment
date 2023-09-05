using Backend.Application.Features.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(PostProductCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            result => Ok(result),
            error => Problem("error")
        );
    }
}