using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPIDemo.Data;
using ProductAPIDemo.Models;

namespace ProductAPIDemo.Controllers
{
    [Route("api/[controller]")] // api/suppliers
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ApplicationDBContext _dbcontext;

        public SuppliersController(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET: api/suppliers - Get all suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var suppliers = await _dbcontext.Suppliers.ToListAsync();
            return Ok(suppliers);
        }

        // GET: api/suppliers/1 - Get supplier by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var supplier = await _dbcontext.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound(new { message = "Supplier not found" });
            }
            return Ok(supplier);
        }

        // POST: api/suppliers - Create a new supplier
        [HttpPost]
        public async Task<ActionResult<Supplier>> CreateSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbcontext.Suppliers.Add(supplier);
            await _dbcontext.SaveChangesAsync();
            return Ok(supplier);
        }

        // PUT: api/suppliers/1 - Update an existing supplier
        [HttpPut("{id}")]
        public async Task<ActionResult<Supplier>> UpdateSupplier(int id, Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return BadRequest(new { message = "Supplier ID mismatch" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSupplier = await _dbcontext.Suppliers.FindAsync(id);
            if (existingSupplier == null)
            {
                return NotFound(new { message = "Supplier not found" });
            }

            existingSupplier.Name = supplier.Name;
            existingSupplier.Address = supplier.Address;
            existingSupplier.ContactNumber = supplier.ContactNumber;
            existingSupplier.Email = supplier.Email;

            await _dbcontext.SaveChangesAsync();
            return Ok(new { message = "Supplier updated successfully" });
        }

        // DELETE: api/suppliers/1 - Delete a supplier
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var existingSupplier = await _dbcontext.Suppliers.FindAsync(id);
            if (existingSupplier == null)
            {
                return NotFound(new { message = "Supplier not found" });
            }
            _dbcontext.Suppliers.Remove(existingSupplier);
            await _dbcontext.SaveChangesAsync();
            return Ok(new { message = "Supplier deleted successfully" });
        }
    }
}
