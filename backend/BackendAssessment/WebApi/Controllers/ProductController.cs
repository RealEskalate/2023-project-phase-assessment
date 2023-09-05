using Application.Dtos.ProductDto;
using Application.Features.Product.Requests.Commands;
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

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    


    [HttpPost("Add")]
    public async Task<IActionResult> AddProduct([FromBody]CreateProductDto createProduct){
        createProduct.UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
        var command = new CreateProductCommand() {CreateProduct = createProduct};
        var productId = await _mediator.Send(command);
        return ResponseHandler<int?>.HandleResponse(productId, 201);
        
    }
    
    [HttpPut("{productId:int}")]
    public async Task<IActionResult> UpdatePost([FromBody] UpdateProductDto updateProduct, int productId){
        
        updateProduct.Id = productId;
        var command = new UpdateProductCommand() { updateProduct = updateProduct, UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1")};
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit?>.HandleResponse(result, 204);
    }
    
    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> DeleteProduct(int productId){
        var command = new DeleteProductCommand() { Id= productId, UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1")};
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
    
    
     
}