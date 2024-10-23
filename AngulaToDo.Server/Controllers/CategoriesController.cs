using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using AngulaToDo.Server.Services.Interfaces;
using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;

namespace AngulaToDo.Server.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetAllCategories(string userId)
        {
            var categories = await _categoryService.GetAllCategoriesAsync(userId);

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [HttpGet("{userId}/{name}")]
        public async Task<ActionResult> GetCategoryByName(string userId, string name)
        {
            var category = await _categoryService.GetCategoryByNameAsync(userId, name);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> CreateCategory(string userId, CategoryDto categoryDto)
        {
            var category = await _categoryService.CreateCategoryAsync(userId, categoryDto);

            if (category == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{userId}/{categoryId}")]
        public async Task<ActionResult> DeleteCategory(string userId, int categoryId)
        {
            var category = await _categoryService.DeleteCategoryAsync(userId, categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
