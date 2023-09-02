using System;
using System.Collections.Generic;
using System.Linq;
using BookWorm_C_.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_C_.Services
{
    public class SQLProductTypeRepository : IProductTypeRepository
    {
        private readonly BookWormContext _context;

        public SQLProductTypeRepository(BookWormContext context)
        {
            _context = context;
        }

        public void AddProductType(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            _context.SaveChanges();
        }

        public void UpdateProductType(ProductType productType)
        {
            _context.ProductTypes.Attach(productType);
            _context.Entry(productType).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProductType(long id)
        {
            var productType = _context.ProductTypes.Find(id);
            if (productType != null)
            {
                _context.ProductTypes.Remove(productType);
                _context.SaveChanges();
            }
        }

        public List<ProductType> GetAllProductTypes()
        {
            return _context.ProductTypes.ToList();
        }

        public ProductType GetProductTypeById(long id)
        {
            return _context.ProductTypes.Find(id);
        }
    }
}
