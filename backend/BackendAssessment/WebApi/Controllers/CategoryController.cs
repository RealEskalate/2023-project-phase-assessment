using System.Security.Claims;

using Application.DTO.CategoryDTO.DTO;
using Application.Features.CategoryFeature.Requests.Commands;
using Application.Features.CategoryFeature.Requests.Queries;
using Application.Features.ProductFeature.Requests.Queries;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<BaseResponse<List<CategoryResponseDTO>>>> Get()
        {   
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);    
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<CategoryResponseDTO>>> Get(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new GetSingleCategoryQuery());
            return Ok(result);            
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BaseResponse<CategoryResponseDTO>>> CreateCategory([FromBody] CategoryCreateDTO newCategoryData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new CreateCategoryCommand{ NewCategoryData = newCategoryData});
           

            return Ok(result);            
        }
   
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<CategoryResponseDTO>>> UpdateCategory(int id, [FromBody] CategoryUpdateDTO UpdateCategoryData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new UpdateCategoryCommand { Id = id, CategoryUpdateData = UpdateCategoryData});
            
            return Ok(result);
            
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<BaseResponse<int>>>> Delete(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new DeleteCategoryCommand {Id = id });    
                   
            return Ok(result);
            
        }
        
    }
}
