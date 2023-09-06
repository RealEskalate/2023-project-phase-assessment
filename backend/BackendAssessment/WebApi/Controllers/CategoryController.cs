using System.Security.Claims;
using Application.DTOs.Catergories;
using Application.Features.Categories.Request.Command;
using Application.Features.Categories.Request.Queries;
using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategoryController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public async Task<ActionResult<List<CategoryResponseDto>>> GetCategories()
        {
            var categories = await _mediator.Send(new GetAllCategoriesRequest());
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDto>> GetCategoryById(int id)
        {
            var idtoClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (idtoClaim != null)
            {
                var userId = int.Parse(idtoClaim);
                var category = await _mediator.Send(new GetCategoryRequest() { UserId = userId, CategoryId = id });
                return Ok(category);
            }
            else
            {
                return BadRequest("User not found");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto request)
        {
            var idtoClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (idtoClaim != null)
            {
                var Command = new CreateCategoryCommand() { 
                    UserId = int.Parse(idtoClaim),
                    CreateCategoryDto = new CreateCategoryDto() { 
                        Name = request.Name, 
                        Description = request.Description 
                    }
                };
                
                ErrorOr<CategoryResponseDto> category = await _mediator.Send(Command);
                return category.Match<IActionResult>(
                    category => Ok(category),
                    errors => Problem(errors)
                );
            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryResponseDto>> UpdateCategory(int id, UpdateCategoryRequest request)
        {
            var idtoClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (idtoClaim != null)
            {
                var userId = int.Parse(idtoClaim);
                var category = await _mediator.Send(new UpdateCategoryRequest() { 
                    UserId = userId,
                    CategoryId = id,
                    CreateCategoryDto = new CreateCategoryDto() { 
                        Name = request.CreateCategoryDto.Name, 
                        Description = request.CreateCategoryDto.Description 
                    }
                });
                return Ok(category);
            }
            else
            {
                return BadRequest("User not found");
            }
        }  
    }
}