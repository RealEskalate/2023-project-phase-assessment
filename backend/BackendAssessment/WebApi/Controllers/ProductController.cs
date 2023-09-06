using System.Security.Claims;
using Application.DTOs.Products;
using Application.Features.Products.Request.Command;
using Application.Features.Products.Request.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        

        [HttpGet]
        public async Task<ActionResult<List<ProductResponseDto>>> GetProducts()
        {
            var userIdtoClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (userIdtoClaim != null)
            {
                var userId = int.Parse(userIdtoClaim);
                var products = await _mediator.Send(new GetAllProductRequest() { UserId = userId });
                return Ok(products);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductRequest() { Id = id });
            return Ok(product);
        }

        [HttpPost("{category_id}")]
        public async Task<ActionResult<ProductResponseDto>> CreateProduct(int id, CreateProductRequest request)
        {
            var userIdtoClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (userIdtoClaim != null)
            {
                var userId = int.Parse(userIdtoClaim);
                var product = await _mediator.Send(new CreateProductRequest() { 
                    UserId = userId,
                    CategoryId = id, 
                    ProductDetailDto = new ProductDetailDto() { 
                        Name = request.ProductDetailDto.Name, 
                        Description = request.ProductDetailDto.Description, 
                        Price = request.ProductDetailDto.Price 
                    }
                });

                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponseDto>> UpdateProduct(int id, UpdateProductRequest request)
        {
            var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (userIdClaim != null)
            {
                var userId = int.Parse(userIdClaim);
                var product = await _mediator.Send(new UpdateProductRequest() { 
                    UserId = userId,
                    ProductId = id, 
                    ProductDetailDto = new ProductDetailDto() { 
                        Name = request.ProductDetailDto.Name, 
                        Description = request.ProductDetailDto.Description, 
                        Price = request.ProductDetailDto.Price 
                    }
                });
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        async Task<ActionResult> DeleteProduct(int id)
        {
            var userIdClaim = _httpContextAccessor.HttpContext!.User.FindFirstValue("uid");

            if (userIdClaim != null)
            {
                var userId = int.Parse(userIdClaim);
                var product = await _mediator.Send(new DeleteProductRequest() { UserId = userId, ProductId = id });
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}