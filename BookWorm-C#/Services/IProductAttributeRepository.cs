using BookWorm_C_.Entities;

namespace BookWorm_C_.Services
{
    public interface IProductAttributeRepository
    {
        Task<IEnumerable<ProductAttribute>> GetAllProductAttributes();
        Task<ProductAttribute> GetProductAttributeById(long id);
        Task AddProductAttribute(ProductAttribute productAttribute);
        Task DeleteProductAttribute(ProductAttribute productAttribute);
        void UpdateProductAttribute(long id, ProductAttribute updatedProductAttribute);


    }
}
