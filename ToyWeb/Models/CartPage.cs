using ToyData.Models;
using System.Collections.Generic;


namespace ToyWeb.Models
{
    public class CartPage
    {
        public List<ShoppingCart> CartList { get; set; }

        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }
    }
}
