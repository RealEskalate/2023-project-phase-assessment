using Microsoft.AspNetCore.Mvc;
using Application.Contracts;
using Domain.Entites;

namespace WebApi.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return Ok(categories);
        }


        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPost("add")]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            await _categoryRepository.CreateCategoryAsync(category);

            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            await _categoryRepository.UpdateCategoryAsync(category);

            return NoContent();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
