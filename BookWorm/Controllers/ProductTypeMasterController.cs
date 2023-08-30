using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ProductTypeMasterWorm.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductTypeMasterWorm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeMasterController : ControllerBase
    {
        private readonly IProductTypeMaster repository;

        public ProductTypeMasterController(IProductTypeMaster repository)
        {
            this.repository = repository;

        }
        // GET: api/<ProductTypeMastersController>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTypeMaster>>> GetAllProductTypeMasters()
        {
            if (await repository.GetAllProductTypeMaster() == null)
            {
                return NotFound();
            }

            return await repository.GetAllProductTypeMaster();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ProductTypeMaster>> GetById(long id)
        {
            var producttypemaster = await repository.GetProductTypeMaster(id);
            return producttypemaster == null ? NotFound() : producttypemaster;
        }

       

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTypeMaster(int id, ProductTypeMaster producttypemaster)
        {
            if (id != producttypemaster.typeId)
            {
                return BadRequest();
            }
            try
            {
                await repository.Update(id, producttypemaster);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (repository.GetProductTypeMaster(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/ProductTypeMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTypeMaster>> PostProductTypeMaster(ProductTypeMaster ProductTypeMaster)
        {
            await repository.Add(ProductTypeMaster);
            return CreatedAtAction("PostProductTypeMaster", new { id = ProductTypeMaster.typeId }, ProductTypeMaster);
        }
        // DELETE: api/ProductTypeMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTypeMaster(int id)
        {
            if (repository.GetAllProductTypeMaster() == null)
            {
                return NotFound();
            }

            await repository.Delete(id);
            return NoContent();
        }
    }
}
