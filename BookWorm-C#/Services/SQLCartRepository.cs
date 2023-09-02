using System;
using System.Collections.Generic;
using System.Linq;
using BookWorm_C_.Entities;
//using BookWorm_C_.Services;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_C_.Services
{
    public class SQLCartRepository : ICartRepository
    {
        private readonly BookWormContext _dbContext;

        public SQLCartRepository(BookWormContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _dbContext.Carts
                .Include(c => c.CustomerCustomer)
                .Include(c => c.ProductProduct)
                .ToList();
        }

        public Cart GetCartById(long cartId)
        {
            return _dbContext.Carts
                .Include(c => c.CustomerCustomer)
                .Include(c => c.ProductProduct)
                .FirstOrDefault(c => c.CartId == cartId);
        }

        public void AddCart(Cart cart)
        {
            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            _dbContext.Carts.Update(cart);
            _dbContext.SaveChanges();
        }

        public void DeleteCart(long cartId)
        {
            var cart = _dbContext.Carts.Find(cartId);
            if (cart != null)
            {
                _dbContext.Carts.Remove(cart);
                _dbContext.SaveChanges();
            }
        }
    }
}
