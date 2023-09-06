using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Application.DTOs.Product;
using Application.Features.Product.Handlers.Commands;
using Application.Features.Product.Handlers.Queries;
using Application.Features.Product.Requests.Commands;
using Application.Features.Product.Requests.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// using Application.Constants;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    // [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            
            _httpContextAccessor = httpContextAccessor;
            
        }

        [HttpGet()]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var products =  await _mediator.Send(new GetProductsRequest());
            return Ok(products);
        }
      
        

        [HttpPost()]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductDto product)
        {

            var userId = new Guid();
            var command = new CreateProductRequest { CreateProductDto = product, UserId = userId };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] UpdateProductDto product)
        {
          
            var command = new UpdateProductRequest{ UpdateProductDto = product};
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{productId:Guid}")]
        public async Task<ActionResult> Delete(DeleteProductDto product)
        {
            
            var userId = new Guid();
            var command = new DeleteProductRequest {DeleteProductDto = product};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}