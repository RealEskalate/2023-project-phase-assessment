using Application.DTO.Categories;
using Application.DTO.Users;
using Application.Features.Categorys.Request.Command;
using Application.Features.Categorys.Request.Query;
using Application.Features.Users.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IHttpContextAccessor _contextAccessor;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
           // _contextAccessor = httpContextAccessor;

        }

        //get category by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
            return Ok(category);
        }

        //create category by CategoryDto
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto _categoryDto)
        {
            var category = await _mediator.Send(new CreateCategoryCommand { categoryDto = _categoryDto });
            return Ok(category);
        }

        //update category by CategoryDto
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto _categoryDto)
        {
            var category = await _mediator.Send(new UpdateCategoryCommand { categoryDto = _categoryDto });
            return Ok(category);
        }




    }
}
