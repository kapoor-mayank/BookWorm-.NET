using BookWorm_C_.Entities;

namespace BookWorm_C_.Services
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetAllCarts();

        Cart GetCartById(long cartId);
        void AddCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(long cartId);

    }
}
