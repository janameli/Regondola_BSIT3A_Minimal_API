using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPIDemo.Data;
using ProductAPIDemo.Models;

namespace ProductAPIDemo.Controllers
{
    [Route("api/[controller]")] // api/customers
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDBContext _dbcontext;

        public CustomersController(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET: api/customers - Get all customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _dbcontext.Customers.ToListAsync();
            return Ok(customers);
        }

        // GET: api/customers/1 - Get customer by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _dbcontext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(new { message = "Customer not found" });
            }
            return Ok(customer);
        }

        // POST: api/customers - Create a new customer
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbcontext.Customers.Add(customer);
            await _dbcontext.SaveChangesAsync();
            return Ok(customer);
        }

        // PUT: api/customers/1 - Update an existing customer
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest(new { message = "Customer ID mismatch" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCustomer = await _dbcontext.Customers.FindAsync(id);
            if (existingCustomer == null)
            {
                return NotFound(new { message = "Customer not found" });
            }

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.ContactNumber = customer.ContactNumber;
            existingCustomer.Address = customer.Address;

            await _dbcontext.SaveChangesAsync();
            return Ok(new { message = "Customer updated successfully" });
        }

        // DELETE: api/customers/1 - Delete a customer
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var existingCustomer = await _dbcontext.Customers.FindAsync(id);
            if (existingCustomer == null)
            {
                return NotFound(new { message = "Customer not found" });
            }
            _dbcontext.Customers.Remove(existingCustomer);
            await _dbcontext.SaveChangesAsync();
            return Ok(new { message = "Customer deleted successfully" });
        }
    }
}
