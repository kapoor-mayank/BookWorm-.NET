using BookWorm_C_.Entities;

namespace BookWorm_C_.Services
{
    public interface IProductMasterRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(long id);
        Task AddProduct(Product product);
        Task DeleteProduct(Product product);
        Task<Product> UpdateProduct(long id, Product updatedProduct);

        // other CRUD operations and custom queries here
        Task<IEnumerable<Product>> GetProductsByType(long typeId);

    }
}
