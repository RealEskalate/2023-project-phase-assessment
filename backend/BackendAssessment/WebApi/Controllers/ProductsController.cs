using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Product;
using Application.Features.Products.Requests.Commands;
using Application.Features.Products.Requests.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        [HttpGet("products/{productId:Guid}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid productId)
        {
            var product = await _mediator.Send(new GetProductDetailRequest() { Id = productId });
            return Ok(product);
        }

        [HttpGet("products/search/{name:string}")]
        public async Task<ActionResult<List<ProductListDto>>> SearchProductsByName(string name, int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 1)
            {
                return BadRequest("Invalid page index or page size.");
            }

            var products = await _mediator.Send(new SearchProductsByNameRequest { Name = name, PageIndex = pageIndex, PageSize = pageSize });
            return Ok(products);
        }

        [HttpGet("catagories/{catagoryId:Guid}/products")]
        public async Task<ActionResult<List<ProductsByCatagoryDto>>> FilterProductsByCatagoryId(Guid catagoryId, int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 1)
            {
                return BadRequest("Invalid page index or page size.");
            }

            var products = await _mediator.Send(new FilterProductsByCatagoryIdRequest { CatagoryId = catagoryId, PageIndex = pageIndex, PageSize = pageSize });
            return Ok(products);
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<ProductListDto>>> GetAllProducts(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 1)
            {
                return BadRequest("Invalid page index or page size.");
            }
            
            var products = await _mediator.Send(new GetAllProductsRequest { PageIndex = pageIndex, PageSize = pageSize });
            return Ok(products);
        }

        [HttpPost("products")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductDto product)
        {
            // var id = _httpContextAccessor.HttpContext!.User.FindFirstValue(CustomClaimTypes.Uid) ?? throw new UnauthorizedAccessException("User is not authorized.");
            // var userId = new Guid(id);
            var command = new CreateProductCommand { CreateProductDto = product };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("products")]
        public async Task<ActionResult> Put([FromBody] UpdateProductDto product)
        {
            // var id = _httpContextAccessor.HttpContext!.User.FindFirstValue(CustomClaimTypes.Uid) ?? throw new UnauthorizedAccessException("User is not authorized.");
            // var userId = new Guid(id);
            var command = new UpdateProductCommand { UpdateProductDto = product };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("products/{productId:Guid}")]
        public async Task<ActionResult> Delete(Guid productId)
        {
            // var id = _httpContextAccessor.HttpContext!.User.FindFirstValue(CustomClaimTypes.Uid) ?? throw new UnauthorizedAccessException("User is not authorized.");
            // var userId = new Guid(id);
            var command = new DeleteProductCommand { Id = productId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}