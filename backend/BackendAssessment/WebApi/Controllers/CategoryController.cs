using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendAssessment.Application.Features.Category.Commands.Requests;
using BackendAssessment.Application.Features.Category.DTO;
using BackendAssessment.Application.Features.Category.Commands.Handlers;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace BackendAssessment.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            var command = new CreateCategoryCommand { createCategoryDto = createCategoryDto };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand { deleteCategoryDto = new DeleteCategoryDto { Id = id } };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var command = new UpdateCategoryCommand { updateCategoryDto = updateCategoryDto };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
