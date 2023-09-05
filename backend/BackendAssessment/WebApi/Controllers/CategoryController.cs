using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategoryDtos;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Application.Features.Categories.Commands.Requests;
using ProductHub.Application.Features.Categories.Queries.Requests;
using ProductHub.Domain.Entities;

namespace ProductHub.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CommonResponse<int>>> GetCategories()
        {
            var query = new GetAllCategoriesQuery();
            var response = await _mediator.Send(query);
            if(response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommonResponse<int>>> GetCategory(int id)
        {
            var query = new GetCategoryByIdQuery{Id = id};
            var response = await _mediator.Send(query);
            if(response.IsSuccess){
                return Ok(response.Value);
            }
            else{
                return BadRequest(response.Error);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            var command = new CreateCategoryCommand
            {
                CreateCategoryDto = categoryDto
            };

            var response = await _mediator.Send(command);
            if(response.IsSuccess){
                return CreatedAtAction(nameof(GetCategory), new { id = response.Value }, response.Value);
            }
            return BadRequest(response.Error);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest();
            }

            var command = new UpdateCategoryCommand
            {
                UpdateCategoryDto = categoryDto
            };
            var response = await _mediator.Send(command);
            if(response.IsSuccess){
                return Ok(response.Value);
            }
            return BadRequest(response.Error);            

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var categoryDto = new DeleteCategoryDto{
                Id = id
            };
            var command = new DeleteCategoryCommand{
                DeleteCategoryDto = categoryDto
            };
            var response =  await _mediator.Send(command);
            if(response.IsSuccess){
                return Ok(response.Value);
            }
            return BadRequest(response.Error);
        }

    }
}
