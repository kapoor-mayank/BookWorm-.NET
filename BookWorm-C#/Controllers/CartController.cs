using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookWorm_C_.Entities;
using BookWorm_C_.Services;
using Microsoft.AspNetCore.Cors;

namespace BookWorm_C_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("*")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cart>> GetAllCarts()
        {
            var carts = _cartRepository.GetAllCarts();
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public ActionResult<Cart> GetCartById(long id)
        {
            var cart = _cartRepository.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost]
        public ActionResult<Cart> AddCart(Cart cart)
        {
            _cartRepository.AddCart(cart);
            return CreatedAtAction(nameof(GetCartById), new { id = cart.CartId }, cart);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCart(long id, Cart cart)
        {
            if (id != cart.CartId)
            {
                return BadRequest();
            }

            _cartRepository.UpdateCart(cart);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCart(long id)
        {
            var cart = _cartRepository.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }

            _cartRepository.DeleteCart(id);
            return NoContent();
        }
    }
}
