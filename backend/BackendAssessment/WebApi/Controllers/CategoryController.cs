
using Application.DTO.CategoryDTO;
using Application.Features.CategoryFeature.Requests;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Middleware;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator){
        _mediator = mediator;
    }

    [HttpGet("{CategoryId:int}")]
    public async Task<IActionResult> GetCategoryId(int CategoryId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
    {
        var command = new GetCategoryByIdRequest() { Id = CategoryId };
        var category = await _mediator.Send(command);
        return ResponseHandler<Category>.HandleResponse(category, 200);
    }



    [HttpGet]
    public async Task<IActionResult> GetAll( [FromQuery] string? tag,
        [FromQuery] int? pageNumber, [FromQuery] int? pageSize){
        var command = new GetAllCategoryRequest(){ PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
        var posts = await _mediator.Send(command);
        return ResponseHandler<List<CategoryListDTO>>.HandleResponse(posts, 200);
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
    public async Task<IActionResult> AddPost([FromBody]CategoryDTO createCategory){
        string token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
        var command = new CreateCategoryRequest(){
            Create = createCategory, Token = token
            
        };
        var category = await _mediator.Send(command);
        return ResponseHandler<Category>.HandleResponse(category, 201);
    }

    [HttpPut("{productId:int}")]
    public async Task<IActionResult> UpdatePost([FromBody] UpdateCategoryDTO updateCategory, int productId){
        string token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
        updateCategory.Id = productId;
        var command = new UpdateCategoryRequest() { Update= updateCategory, Token = token};
        var result = await _mediator.Send(command);
        return ResponseHandler<Category>.HandleResponse(result, 204);
    }
    
    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> DeletePost(int productId){
        string token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
        var command = new DeleteCategoryRequest() { CategoryId = productId, Token = token };
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
}