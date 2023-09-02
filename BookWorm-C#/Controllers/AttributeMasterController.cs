using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWorm_C_.Entities; // Update the namespace to match your entity's namespace
using BookWorm_C_.Services; // Update the namespace to match your repository's namespace
using Microsoft.AspNetCore.Cors;

namespace BookWorm_C_.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("*")]
public class AttributeMasterController : ControllerBase
    {
        private readonly IAttributeMasterRepository _attributeRepository;

        public AttributeMasterController(IAttributeMasterRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAttributes()
        {
            var attributes = await _attributeRepository.GetAllAttributeAsync();
            return Ok(attributes);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAttribute(AttributeMaster attribute)
        {
            await _attributeRepository.AddAttributeAsync(attribute);
            return CreatedAtAction(nameof(GetAllAttributes), new { }, null);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAttribute(long id, AttributeMaster attribute)
        {
            await _attributeRepository.UpdateAsync(attribute, id);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAttribute(long id)
        {
            await _attributeRepository.DeleteAsync(id);
            return NoContent();
        }
    }

