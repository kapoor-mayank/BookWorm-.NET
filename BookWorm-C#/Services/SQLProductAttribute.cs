using BookWorm_C_.Entities;
using BookWorm_C_.Services;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_C_.Services
{
    public class SQLProductAttributeRepository : IProductAttributeRepository
    {
        private readonly BookWormContext _context;

        public SQLProductAttributeRepository(BookWormContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductAttribute>> GetAllProductAttributes()
        {
            return await _context.ProductAttributes.ToListAsync();
        }

        public async Task<ProductAttribute> GetProductAttributeById(long id)
        {
            return await _context.ProductAttributes.FindAsync(id);
        }

        public async Task AddProductAttribute(ProductAttribute productAttribute)
        {
            _context.ProductAttributes.Add(productAttribute);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAttribute(ProductAttribute productAttribute)
        {
            _context.ProductAttributes.Remove(productAttribute);
            await _context.SaveChangesAsync();
        }

        public void UpdateProductAttribute(long id, ProductAttribute updatedProductAttribute)
        {
            var existingProductAttribute = _context.ProductAttributes.Find(id);
            if (existingProductAttribute != null)
            {
                existingProductAttribute.AttributeValue = updatedProductAttribute.AttributeValue;
                // Update other properties as needed
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Product attribute not found.");
            }
        }
    }
}
