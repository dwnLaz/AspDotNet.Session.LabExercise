using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyData.Data;
using ToyData.Models;

namespace ToyData.Repositories
{
    public interface ICartRepository : IBaseRepository<ShoppingCart>
    {
    }

    public class CartRepository : GenericRepository<ShoppingCart>, ICartRepository
    {
        public CartRepository(ToyUniverseContext context) : base(context)
        {
        }
    }
}
