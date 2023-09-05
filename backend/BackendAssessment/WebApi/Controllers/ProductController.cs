
using Application.DTO.ProductDTO;
using Application.Features.ProductFeature.Requests;
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

    public ProductController(IMediator mediator){
        _mediator = mediator;
    }

    // [HttpGet("User/{userId:int}")]
    // public async Task<IActionResult> GetUserPosts(int userId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
    // {
    //     var command = new GetUserPostRequest() { Id = userId, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
    //     var posts = await _mediator.Send(command);
    //     return ResponseHandler<List<PostDto>>.HandleResponse(posts, 200);
    // }

    
    
    // [HttpGet]
    // public async Task<IActionResult> GetPosts([FromQuery] string? search, [FromQuery] string? tag,  [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
    // {
    //
    //     if (!string.IsNullOrEmpty(search))
    //     {
    //         var command = new GetByContenetRequest() { Contenet = search, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
    //         var posts = await _mediator.Send(command);
    //         return ResponseHandler<List<PostDto>>.HandleResponse(posts, 200);
    //     }
    //     else if (!string.IsNullOrEmpty(tag))
    //     {
    //         var command = new GetByTagRequest { Tag = tag, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
    //         var posts = await _mediator.Send(command);
    //         return ResponseHandler<List<PostDto>>.HandleResponse(posts, 200);
    //     }
    //     else
    //     {
    //         var command = new GetFollowingPostRequest{Id = int.Parse(User.FindFirst("reader")?.Value ?? "-1"), PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10};
    //         var posts = await _mediator.Send(command);
    //         return ResponseHandler<List<PostDto>>.HandleResponse(posts, 200);
    //     }
    // }
    
   
    
    [HttpPost("Add")]
    public async Task<IActionResult> AddPost([FromBody]CreateProductDTO createProduct){
        string token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
        var command = new CreateProductRequest(){
            Create = createProduct, Token = token
            
        };
        var product = await _mediator.Send(command);
        return ResponseHandler<ProductListDTO>.HandleResponse(product, 201);
    }

    [HttpPut("{productId:int}")]
    public async Task<IActionResult> UpdatePost([FromBody] UpdateProductDTO updateProduct, int productId){
        string token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
        updateProduct.Id = productId;
        var command = new UpdateProductRequest() { Update= updateProduct, Token = token};
        var result = await _mediator.Send(command);
        return ResponseHandler<ProductListDTO>.HandleResponse(result, 204);
    }
    
    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> DeletePost(int productId){
        string token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
        var command = new DeleteProductRequest() { ProductId = productId, Token = token };
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
}