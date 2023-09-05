using System.Security.Claims;

using Application.DTO.ProductDTO.DTO;
using Application.Features.ProductFeature.Requests.Commands;
using Application.Features.ProductFeature.Requests.Queries;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<BaseResponse<List<ProductResponseDTO>>>> Get()
        {   
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new GetAllProductsQuery { userId = userId});
            return Ok(result);    
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<ProductResponseDTO>>> Get(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new GetSingleProductQuery { Id = id, userId = userId });
            return Ok(result);            
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BaseResponse<ProductResponseDTO>>> CreateProduct([FromBody] ProductCreateDTO newProductData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new CreateProductCommand{ NewProductData = newProductData, userId = userId });
           

            return Ok(result);            
        }
   
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<ProductResponseDTO>>> UpdateProduct(int id, [FromBody] ProductUpdateDTO UpdateProductData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new UpdateProductCommand { Id = id, ProductUpdateData = UpdateProductData , userId = userId });
            
            return Ok(result);
            
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<BaseResponse<int>>>> Delete(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new DeleteProductCommand { userId = userId, Id = id });    
                   
            return Ok(result);
            
        }
        
    }
}
