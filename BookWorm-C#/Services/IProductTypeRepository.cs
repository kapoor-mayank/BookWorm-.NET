using System;
using System.Collections.Generic;

namespace BookWorm_C_.Entities
{
    public interface IProductTypeRepository
    {
        void AddProductType(ProductType productType);

        void UpdateProductType(ProductType productType);

        void DeleteProductType(long id);

        List<ProductType> GetAllProductTypes();

        ProductType GetProductTypeById(long id);
    }
}
