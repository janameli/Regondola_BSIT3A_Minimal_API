using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPIDemo.Data;
using ProductAPIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbcontext;

        public ProductsController(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // .Include allows you to see the Category and Supplier details in the response
            var products = await _dbcontext.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _dbcontext.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/products 
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbcontext.Products.Add(product);
            await _dbcontext.SaveChangesAsync();

            // Using CreatedAtAction is the standard way to return a 201 Created response
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest(new { message = "Product ID mismatch" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = await _dbcontext.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            // Update core values
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            // NEW: Update Relationship IDs
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.SupplierId = product.SupplierId;

            await _dbcontext.SaveChangesAsync();

            return Ok(new { message = "Product updated successfully" });
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")] // Fixed the route parameter to match standard practice
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _dbcontext.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            _dbcontext.Products.Remove(existingProduct);
            await _dbcontext.SaveChangesAsync();
            return Ok(new { message = "Product deleted successfully" });
        }
    }
}