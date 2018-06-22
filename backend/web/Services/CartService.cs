using System.Collections.Generic;

namespace backend.Services
{
    public interface ICartService
    {
        void AddToCart(int productId);
    }

    public class CartService : ICartService
    {
        private List<int> _products = new List<int>();

        public void AddToCart(int productId)
        {
            _products.Add(productId);
        }
    }
}