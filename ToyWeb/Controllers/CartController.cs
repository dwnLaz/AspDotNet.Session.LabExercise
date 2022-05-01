using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToyData.Models;
using ToyData.Repositories;
using ToyWeb.Services;
using ToyWeb.Extensions;

namespace ToyWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly IToyRepository toyRepository;
        private readonly IToyService toyService;
        private readonly ICartService cartService;

        public CartController(IToyService toyService, IToyRepository toyRepository, ICartService cartService)
        {
            this.toyService = toyService;
            this.toyRepository = toyRepository;
            this.cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.Get("cart") == null)
            {
                List<ShoppingCart> cart = new List<ShoppingCart>();

                HttpContext.Session.SetObject("cart", cart);
            }
            return View(cartService.GetCartPage(1));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(cartService.GetCartPage(currentPageIndex));
        }

        private int isExist(string id)
        {
            List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].CToy.CToyId.Equals(id))
                    return i;
            return -1;
        }

        public ActionResult Add(string id)
        {
            if (HttpContext.Session.GetObject<List<ShoppingCart>>("cart") == null)
            {
                List<ShoppingCart> cart = new List<ShoppingCart>();
                cart.Add(new ShoppingCart { CToy = toyRepository.FindByPrimaryKey(id), SiQty = 1 });
                HttpContext.Session.SetObject("cart", cart);
            }
            else
            {
                List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].SiQty++;
                }
                else
                {
                    cart.Add(new ShoppingCart { CToy = toyRepository.FindByPrimaryKey(id), SiQty = 1 });
                }
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }

    }
}
