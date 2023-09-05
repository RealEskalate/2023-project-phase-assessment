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
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IHttpContextAccessor _contextAccessor;

        public ProductController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
        }
        // GET: api/<ProductControlle>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var products = await _mediator.Send(new GetAllProductsRequest { UserId = new Guid(Id)});
            return Ok(products);
            
        }

        // GET api/<ProductController>/5
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ProductDto>> GetAProduct(Guid id)
        {
            var product = await _mediator.Send(new GetProductDetailsRequest { Id = id });
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProductDto createProductDto)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            createProductDto.UserId = new Guid(Id);

            var command = new CreateProductCommand { CreateProductDto = createProductDto };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var product = await _mediator.Send(new GetProductDetailsRequest { Id = updateProductDto.Id });
            if (product.UserId != new Guid(Id))
            {
                throw new Exception("you dont own the current product");
            }
            var command = new UpdateProductCommand {  UpdateProductDto = updateProductDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var product = await _mediator.Send(new GetProductDetailsRequest { Id = id });
            if (product.UserId != new Guid(Id))
            {
                throw new Exception("you dont own the current product");
            }
            var command = new DeleteProductRequest { Id = id };
            await _mediator.Send(command);
            return NoContent();


        }
    }
}
