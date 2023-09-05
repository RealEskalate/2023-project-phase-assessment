using Application.DTOs.Product;
using Application.Features.Products.Requests.Commands;
using Application.Responses;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
    {
        var request = new CreateProductCommand() { ProductDto = productDto };
        var response = await _mediator.Send(request);

        return ResponseHandler<Product>.HandleResponse(response, 201);
    }
}