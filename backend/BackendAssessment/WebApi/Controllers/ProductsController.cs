using Microsoft.AspNetCore.Mvc;
using Application.Contracts;
using Domain.Entites;

namespace WebApi.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("getById/{ProductId}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost("add")]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            await _productRepository.CreateProductAsync(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        // PUT: api/products/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            await _productRepository.UpdateProductAsync(product);

            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("delete/{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
