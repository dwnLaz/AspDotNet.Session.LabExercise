using System;
using System.Linq;
using ToyData.Data;
using ToyData.Models;
using ToyData.Repositories;
using ToyWeb.Models;


namespace ToyWeb.Services
{
    public interface ICartService
    {
        public PagedResult<ShoppingCart> GetCartPage(int currentPage);
    }

    public class CartService : GenericService, ICartService
    {
        private ICartRepository cartRepository;
        public CartService(ICartRepository cartRepository, ToyUniverseContext context)
        {
            this.cartRepository = cartRepository;
        }
        public PagedResult<ShoppingCart> GetCartPage(int currentPage)
        {
            return GetPaged<ShoppingCart>(cartRepository.Context.ShoppingCarts, currentPage, 7);
        }
    }
}
