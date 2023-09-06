using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Application.DTOs.Product;
using Application.Features.Category.Handlers.Commands;
using Application.Features.Category.Handlers.Queries;
using Application.Features.Category.Requests.Commands;
using Application.Features.Category.Requests.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// using Application.Constants;
using Microsoft.AspNetCore.Authorization;
using Application.DTOs.Category;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    // [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            
            _httpContextAccessor = httpContextAccessor;
            
        }

        [HttpGet()]
        public async Task<ActionResult<List<ProductDto>>> GetCategories()
        {
            var categories =  await _mediator.Send(new GetCategoriesRequest());
            return Ok(categories);
        }
      
        

        [HttpPost()]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] ICategoryDto cate)
        {
           
            var command = new CreateCategoryRequest { ICategoryDto = cate};
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] UpdateCategoryDto cate)
        {
          
            var command = new UpdateCategoryRequest{ UpdateCategoryDto = cate};
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{categoryId:Guid}")]
        public async Task<ActionResult> Delete(DeleteCategoryDto cate)
        {
            
            var userId = new Guid();
            var command = new DeleteCategoryRequest {DeleteCategoryDto = cate};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}