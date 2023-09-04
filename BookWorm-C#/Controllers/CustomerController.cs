using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWorm_C_.Entities; // Update the namespace to match your entity's namespace
using BookWorm_C_.Services; // Update the namespace to match your service's namespace
using Microsoft.AspNetCore.Cors;

namespace BookWorm_C_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("*")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerService;

        public CustomerController(ICustomerRepository customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            try
            {
                await _customerService.AddCustomerAsync(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(long id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}