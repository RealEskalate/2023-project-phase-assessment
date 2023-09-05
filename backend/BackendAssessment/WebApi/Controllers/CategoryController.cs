using Application.Common;
using Application.DTO.Category.DTO;
using Application.Features.CategoryFeature.Requests.Commands;
using Application.Features.CategoryFeature.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<CategoryResponseDTO>>>> Get()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<CategoryResponseDTO>>> Get(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIDQuery() { CategoryId = id });

            return Ok(result);
        }
        [HttpPost]
        public  async Task<ActionResult<BaseResponse<CategoryResponseDTO>>> Post([FromBody] CategoryCreateDTO category)
        {
            var result = await _mediator.Send(new CreateCategoryCommand() { CategoryData = category });

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<CategoryResponseDTO>>> Put(int id, [FromBody] CategoryUpdateDTO category)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand() { CategoryData = category });

            return Ok(result);
        }

       
    }
}
