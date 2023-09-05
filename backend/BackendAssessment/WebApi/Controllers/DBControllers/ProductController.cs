using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.Product;
using Application.Features.Products.Request.Command;
using Application.Features.Products.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<GetProductDto>> GetProductById(Guid productId)
        {
            var query = new GetProductByIdRequest { Id = productId };
            var product = await _mediator.Send(query);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDto createProductDTO)
        {
            var command = new CreateProductCommand { createProductDTO = createProductDTO };
            await _mediator.Send(command);

            return CreatedAtAction(nameof(GetProductById), new { productId = createProductDTO.UserId }, createProductDTO);
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto updateProductDTO)
        {
            var command = new UpdateProductCommand { updateProductDTO = updateProductDTO };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
