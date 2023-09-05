
using System.Security.Claims;
using BackendAssessment.Application.DTOs.ProductDtos;
using BackendAssessment.Application.Features.Products.Handlers.Commands;
using BackendAssessment.Application.Features.Products.Requests.Commands;
using BackendAssessment.Application.Features.Products.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Products = await _mediator.Send(new GetAllProductsRequest());
        return Ok(Products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var request = new GetProductRequest() { Id = id };
        var Product = await _mediator.Send(request);
        return Ok(Product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto Product)
    {
        // Add user Id to the dto from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        Product.UserId = userId;
        
        var request = new CreateProductRequest() { ProductDto = Product };
        var createdProduct = await _mediator.Send(request);
        return Ok(createdProduct);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(ProductDto Product)
    {
        // Add user Id to the dto from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        Product.UserId = userId;
        
        var request = new UpdateProductRequest() { ProductDto = Product };
        var updatedProduct = await _mediator.Send(request);
        return Ok(updatedProduct);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var request = new DeleteProductRequest() { Id = id };
        await _mediator.Send(request);
        return NoContent();
    }
}