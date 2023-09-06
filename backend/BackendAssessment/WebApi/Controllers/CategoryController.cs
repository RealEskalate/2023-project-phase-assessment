using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Application.DTOs.Category;
using Application.Features.Categories.Request.Command;
using Application.Features.Categories.Request.Queries;
using Application.Features.Categories.Request.Queries;
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
        public async Task<ActionResult<CategoryRetriveDto>> GetCategoryById(Guid categoryId)
        {
            var query = new GetCategoryRequest { id = categoryId };
            var category = await _mediator.Send(query);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CategoryRetriveDto createCategoryDTO)
        {
            var command = new CreateCategoryCommand { name = createCategoryDTO.name , description = createCategoryDTO.description};
            await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = createCategoryDTO.Id }, createCategoryDTO);
        }

        [HttpPut("{categoryId}")]
        public async Task<ActionResult> UpdateCategory(CategoryRetriveDto updateCategoryDTO)
        {

            var command = new UpdateCategoryCommand {name = updateCategoryDTO.name, description = updateCategoryDTO.description };
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
