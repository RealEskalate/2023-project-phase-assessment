using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Application.Features.Products.Commands.Requests;
using ProductHub.Application.Features.Products.Queries.Requests;
using ProductHub.Domain.Entities;

namespace YourNamespace.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CommonResponse<int>>> GetProducts()
        {
            var query = new GetAllProductsQuery();
            var response = await _mediator.Send(query);
            if(response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommonResponse<int>>> GetProduct(int id)
        {
            var query = new GetProductByIdQuery{Id = id};
            var response = await _mediator.Send(query);
            if(response.IsSuccess){
                return Ok(response.Value);
            }
            else{
                return BadRequest(response.Error);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductDto productDto)
        {
            var command = new CreateProductCommand
            {
                CreateProductDto = productDto
            };

            var response = await _mediator.Send(command);
            if(response.IsSuccess){
                return CreatedAtAction(nameof(GetProduct), new { id = response.Value }, response.Value);
            }
            return BadRequest(response.Error);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var command = new UpdateProductCommand
            {
                UpdateProductDto = productDto
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
            var productDto = new DeleteProductDto{
                Id = id
            };
            var command = new DeleteProductCommand{
                DeleteProductDto = productDto
            };
            var response =  await _mediator.Send(command);
            if(response.IsSuccess){
                return Ok(response.Value);
            }
            return BadRequest(response.Error);
        }

        [HttpPost("product-name/{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var query = new GetProductsByNameQuery{Name = name};
            var response =  await _mediator.Send(query);
            return Ok(response.Value);
        }

        [HttpPost("product-category/{categoryId}")]
        public async Task<IActionResult> GetProductByName(int categoryId)
        {
            var query = new GetProductsByCategoryIdQuery{Id = categoryId};
            var response =  await _mediator.Send(query);
            return Ok(response.Value);
        }

        [HttpPost("product-pricing")]
        public async Task<IActionResult> GetProductByPrice([FromQuery] double startingPrice, [FromQuery] double finalPrice)
        {
            var query = new GetProductsByPriceRangeQuery{
                startingPrice = startingPrice,
                finalPrice = finalPrice
            };
            var response =  await _mediator.Send(query);
            return Ok(response.Value);
        }

        [HttpGet("available-products")]
        public async Task<IActionResult> GetAvailableProducts()
        {
            var query = new GetProductsByAvailabilityQuery{Availability = Availability.IsAvailable};
            var response =  await _mediator.Send(query);
            return Ok(response.Value);
        }

        [HttpGet("comming-soon")]
        public async Task<IActionResult> GetCommingSoonProducts()
        {
            var query = new GetProductsByAvailabilityQuery{Availability = Availability.CommingSoon};
            var response =  await _mediator.Send(query);
            return Ok(response.Value);
        }


    }
}
