using BookWorm_C_.Entities;
using BookWorm_C_.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_C_.Controllers
{
    [Route("api/productattributes")]
    [ApiController]
    [EnableCors("*")]

    public class ProductAttributeController : ControllerBase
    {
        private readonly IProductAttributeRepository _productAttributeRepository;

        public ProductAttributeController(IProductAttributeRepository productAttributeRepository)
        {
            _productAttributeRepository = productAttributeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductAttributes()
        {
            try
            {
                var attributes = await _productAttributeRepository.GetAllProductAttributes();
                return Ok(attributes);
            }
            catch (Exception e)
            {
                return BadRequest("Failed: " + e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAttribute(long id)
        {
            try
            {
                var attribute = await _productAttributeRepository.GetProductAttributeById(id);
                if (attribute != null)
                {
                    return Ok(attribute);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest("Failed: " + e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAttribute([FromBody] ProductAttribute productAttribute)
        {
            try
            {
                await _productAttributeRepository.AddProductAttribute(productAttribute);
                return CreatedAtAction(nameof(GetProductAttribute), new { id = productAttribute.ProductAttributeId }, productAttribute);
            }
            catch (Exception e)
            {
                return BadRequest("Failed: " + e.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProductAttribute(long id, ProductAttribute updatedProductAttribute)
        {
            try
            {
                _productAttributeRepository.UpdateProductAttribute(id, updatedProductAttribute);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAttribute(long id)
        {
            try
            {
                var attribute = await _productAttributeRepository.GetProductAttributeById(id);
                if (attribute != null)
                {
                    await _productAttributeRepository.DeleteProductAttribute(attribute);
                    return Ok(attribute);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest("Failed: " + e.Message);
            }
        }

    }
}
