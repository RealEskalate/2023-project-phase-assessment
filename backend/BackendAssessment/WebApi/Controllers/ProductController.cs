using Application.DTO.Products;
using Application.Features.Products.Request.Command;
using Application.Features.Products.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;
        public ProductController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = httpContextAccessor;

        }

        //get product by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { Id = id });
            return Ok(result);
        }


        // create product by ProductDto
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
        {
            var result = await _mediator.Send(new CreateProductCommand { productDto = productDto });
            return Ok(result);
        }

        //update product by ProductDto
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        {
            var result = await _mediator.Send(new UpdateProductCommand { product = productDto });
            return Ok(result);
        }

    }
}
