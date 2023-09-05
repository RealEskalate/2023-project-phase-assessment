using Application.Common;
using Application.DTO.Product.DTO;
using Application.Features.ProductsFeature.Requests.Commands;
using Application.Features.ProductsFeature.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<ProductResponseDTO>>>> Get()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<ProductResponseDTO>>> Get(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { Id = id });
            return Ok(result);
        }


        // update
        [HttpPut("{id}")]
        [Authorize("Administrator")]
        public async Task<ActionResult<BaseResponse<ProductResponseDTO>>> Put(int id, [FromBody] ProductUpdateDTO product)
        {
            var result = await _mediator.Send(new UpdateProductCommand { ProductData = product });
            return Ok(result);
        }

        // get by category

        [HttpGet("category")]
        public async Task<ActionResult<BaseResponse<List<ProductResponseDTO>>>> GetByCategory(string category)
        {
            var result = await _mediator.Send(new GetProductsByCategoryQuery { category = category });
            return Ok(result);
        }


        
        [HttpPost("create")]
        [Authorize("Administrator")]
        public async Task<ActionResult<BaseResponse<ProductResponseDTO>>> Post([FromBody] ProductCreateDTO product)
        {
            var result = await _mediator.Send(new CreateProductCommand { ProductData = product });
            return Ok(result);
        }


        // delete
        [HttpDelete("{id}")]
        [Authorize("Administrator")]
        public async Task<ActionResult<BaseResponse<string>>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand { Id = id });
            return Ok(result);
        }

    }
}
