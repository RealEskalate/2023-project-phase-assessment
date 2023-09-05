using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.Category;
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
        public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid categoryId)
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
        public async Task<ActionResult> CreateCategory(CategoryDto createCategoryDTO)
        {
            var command = new CreateCategoryCommand { categoryDTO = createCategoryDTO };
            await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = createCategoryDTO.Id }, createCategoryDTO);
        }

        [HttpPut("{categoryId}")]
        public async Task<ActionResult> UpdateCategory(CategoryDto updateCategoryDTO)
        {

            var command = new UpdateCategoryCommand { categoryDTO = updateCategoryDTO };
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
