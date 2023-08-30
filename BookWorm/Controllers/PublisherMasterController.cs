using BookWorm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookWorm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherMasterController : ControllerBase
    {
        private readonly IPublisherMaster repository;

        public PublisherMasterController(IPublisherMaster repository)
        {
            this.repository = repository;
            
        }
        // GET: api/<PublisherMastersController>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherMaster>>> GetAllPublisherMasters()
        {
            if (await repository.GetAllPublisherMaster() == null)
            {
                return NotFound();
            }

            return await repository.GetAllPublisherMaster();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PublisherMaster>> GetById(long id)
        {
            var Publishermaster = await repository.GetPublisherMaster(id);
            return Publishermaster == null ? NotFound() : Publishermaster;
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisherMaster(int id, PublisherMaster Publishermaster)
        {
            if (id != Publishermaster.publisherId)
            {
                return BadRequest();
            }
            try
            {
                await repository.Update(id, Publishermaster);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (repository.GetPublisherMaster(id) == null)
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

        // POST: api/PublisherMasters
        
        [HttpPost]
        public async Task<ActionResult<PublisherMaster>> PostPublisherMaster(PublisherMaster PublisherMaster)
        {
            await repository.Add(PublisherMaster);
            return CreatedAtAction("PostPublisherMaster", new { id = PublisherMaster.publisherId }, PublisherMaster);
        }
        // DELETE: api/PublisherMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisherMaster(int id)
        {
            if (repository.GetAllPublisherMaster() == null)
            {
                return NotFound();
            }

            await repository.Delete(id);
            return NoContent();
        }
    }
}
