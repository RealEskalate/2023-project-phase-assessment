using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO.Category;
using Application.Features.Categories.Request.Command;
using Application.Features.Categories.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(Guid categoryId)
        {
            var query = new GetCategoryByIdRequest { Id = categoryId };
            var category = await _mediator.Send(query);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CategoryDTO createCategoryDTO)
        {
            var command = new CreateCategoryCommand { categoryDTO = createCategoryDTO };
            await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = createCategoryDTO.Id }, createCategoryDTO);
        }

        [HttpPut("{categoryId}")]
        public async Task<ActionResult> UpdateCategory(CategoryDTO updateCategoryDTO)
        {

            var command = new UpdateCategoryCommand { categoryDTO = updateCategoryDTO };
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
