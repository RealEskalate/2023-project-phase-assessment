using Application.DTO.CategoryDTO;
using Application.DTO.ProductCategoryDTO;
using Application.Features.Category.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Middleware;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetCategories()
        //{
        //    var query = new GetCategoriesQuery();
        //    var categories = await _mediator.Send(query);
        //    return ResponseHandler<List<CategoryDto>>.HandleResponse(categories, 200);
        //}

        //[HttpGet("{categoryId}")]
        //public async Task<IActionResult> GetCategoryById(int categoryId)
        //{
        //    var query = new GetCategoryByIdQuery { CategoryId = categoryId };
        //    var category = await _mediator.Send(query);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return ResponseHandler<CategoryDto>.HandleResponse(category, 200);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto createCategoryDto)
        {
            var command = new CreateCategoryCommand { categoryDto = createCategoryDto};
            var CategoryId = await _mediator.Send(command);
            return ResponseHandler<int>.HandleResponse(CategoryId, 201);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] CategoryDto updateCategoryDto)
        {
            var command = new UpdateCategoryCommand { categoryDto = updateCategoryDto};
            var result = await _mediator.Send(command);
            return ResponseHandler<Unit>.HandleResponse(result, 204);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var command = new DeleteCategoryCommand { Id = categoryId};
            var result = await _mediator.Send(command);
            return ResponseHandler<Unit>.HandleResponse(result, 204);
        }
    }
}
