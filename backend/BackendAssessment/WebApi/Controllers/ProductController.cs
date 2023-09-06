using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs.Product;
using Application.Features.Products.Request.Command;
using Application.Features.Products.Request.Queries;
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
        public async Task<ActionResult<CreateProductDTO>> GetProductById(Guid productId)
        {
            var query = new GetProductRequest { Id = productId };
            var product = await _mediator.Send(query);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            var command = new CreateProductCommand { name = createProductDTO.name , description=createProductDTO.description,
            IsAvailable = createProductDTO.isAvailable,pricing = createProductDTO.pricing};
            await _mediator.Send(command);

            return CreatedAtAction(nameof(GetProductById), new { productId = createProductDTO.Id }, createProductDTO);
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct(CreateProductDTO updateProductDTO)
        {
            var command = new UpdateProductCommand {
                name = updateProductDTO.name,
                description = updateProductDTO.description,
                IsAvailable = updateProductDTO.isAvailable,
                pricing = updateProductDTO.pricing
            };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}

