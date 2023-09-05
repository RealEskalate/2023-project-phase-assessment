using Application.DTO.ProductDTO;
using Application.Features.Product.Requests.Commands;
using Application.Features.Product.Requests.Querie;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Middleware;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize] // You can apply authorization as needed
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var query = new GetProductRequest { Id = productId };
            var product = await _mediator.Send(query);
            return ResponseHandler<ProductDto>.HandleResponse(product, 200);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto createProductDto)
        {
            var command = new CreateProductCommand { Product = createProductDto };
            var productId = await _mediator.Send(command);
            return ResponseHandler<int>.HandleResponse(productId, 201);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductDto updateProductDto)
        {
            //updateProductDto.UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
            var command = new UpdateProductCommand { Product = updateProductDto };
            var result = await _mediator.Send(command);
            return ResponseHandler<Unit>.HandleResponse(result, 204);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var command = new DeleteProductCommand { Id = productId};
            var result = await _mediator.Send(command);
            return ResponseHandler<Unit>.HandleResponse(result, 204);
        }
    }
}
