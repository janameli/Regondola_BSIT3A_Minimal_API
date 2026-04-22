using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPIDemo.Data;
using ProductAPIDemo.Models;

namespace ProductAPIDemo.Controllers
{
    [Route("api/[controller]")] // api/categories
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDBContext _dbcontext;

        public CategoriesController(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET: api/categories - Get all categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _dbcontext.Categories.ToListAsync();
            return Ok(categories);
        }

        // GET: api/categories/1 - Get category by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _dbcontext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            return Ok(category);
        }

        // POST: api/categories - Create a new category
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbcontext.Categories.Add(category);
            await _dbcontext.SaveChangesAsync();
            return Ok(category);
        }

        // PUT: api/categories/1 - Update an existing category
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest(new { message = "Category ID mismatch" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCategory = await _dbcontext.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return NotFound(new { message = "Category not found" });
            }

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            await _dbcontext.SaveChangesAsync();
            return Ok(new { message = "Category updated successfully" });
        }

        // DELETE: api/categories/1 - Delete a category
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var existingCategory = await _dbcontext.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            _dbcontext.Categories.Remove(existingCategory);
            await _dbcontext.SaveChangesAsync();
            return Ok(new { message = "Category deleted successfully" });
        }
    }
}
