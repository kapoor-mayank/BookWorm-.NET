using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Cors;

namespace BookWorm_C_.Controllers
{
    [Route("api/producttypes")]
    [ApiController]
    [EnableCors("*")]

    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeController(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet]
        public ActionResult<List<ProductType>> GetAllProductTypes()
        {
            var productTypes = _productTypeRepository.GetAllProductTypes();
            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductType> GetProductTypeById(long id)
        {
            var productType = _productTypeRepository.GetProductTypeById(id);
            if (productType == null)
            {
                return NotFound();
            }
            return Ok(productType);
        }

        [HttpPost]
        public ActionResult AddProductType(ProductType productType)
        {
            _productTypeRepository.AddProductType(productType);
            return CreatedAtAction(nameof(GetProductTypeById), new { id = productType.ProductTypeId }, productType);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductType(long id, ProductType productType)
        {
            if (id != productType.ProductTypeId)
            {
                return BadRequest();
            }

            _productTypeRepository.UpdateProductType(productType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductType(long id)
        {
            _productTypeRepository.DeleteProductType(id);
            return NoContent();
        }
    }
}
