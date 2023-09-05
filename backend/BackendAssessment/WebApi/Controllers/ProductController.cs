using Application.DTO;
using Application.Features.Product.Requests.Commands;
using Application.Features.Product.Requests.Queries;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Middleware;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }
      
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDTO){
        productDTO.UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
        var command = new CreateProductCommand { ProductDTO = productDTO };
        var productId = await _mediator.Send(command);
        return ResponseHandler<int>.HandleResponse(productId, 201);

    }
    
    
    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateComment([FromBody] ProductDTO updateProduct){
        updateProduct.UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
        var command = new UpdateProductCommand { productDTO = updateProduct };
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
    
    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteComment(int commentId)
    {
        var command = new DeleteProductCommand {ProductId = productId , UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1")};
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
    
    [HttpGet("{ProductId:int}")]
    public async Task<IActionResult> GetComment(int ProductId )
    {
        var query = new GetProductRequest{ ProductId = ProductId };
        var product = await _mediator.Send(query);
        return ResponseHandler<ProductDTO>.HandleResponse(product, 200);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProductByCategoryId([FromQuery]int CategoryId){
        var query = new GetProductByCategoryIdRequest
            { CategoryId = CategoryId};
        var products = await _mediator.Send(query);
        return ResponseHandler<List<ProductDTO>>.HandleResponse(products, 200);
    }
    
}

