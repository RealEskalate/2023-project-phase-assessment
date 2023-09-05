using Application.Contracts.persistence;
using Application.Dtos.Category;
using Application.Dtos.Product;
using Application.Features.Products.Request.Commands;
using Application.Features.Products.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        private readonly IHttpContextAccessor _contextAccessor;

        public CategoryController(IMediator mediator, IHttpContextAccessor contextAccessor, IUserRepository userRepository)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var Categories = await _mediator.Send(new GetAllCategoriesRequest { UserId = new Guid(Id) });
            return Ok(Categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetACategory(int id)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var category = await _mediator.Send(new GetCategoryDetailsRequest { Id = new Guid(Id) });
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCategoryDto createCategoryDto)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var user = await _userRepository.GetById(new Guid(Id));
            if (!user.IsAdmin) {
                throw new Exception("not an admin");
            }
            var command = new CreateCategoryCommand { CreateCategoryDto = createCategoryDto};
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var user = await _userRepository.GetById(new Guid(Id));
            if (!user.IsAdmin)
            {
                throw new Exception("not an admin");
            }
            var command = new UpdateCategoryCommand {UpdateCategoryDto = updateCategoryDto};
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var user = await _userRepository.GetById(new Guid(Id));
            if (!user.IsAdmin)
            {
                throw new Exception("not an admin");
            }
            var command = new DeleteCategoryRequest { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
