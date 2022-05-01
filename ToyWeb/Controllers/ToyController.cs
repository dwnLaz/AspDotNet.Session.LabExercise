using Microsoft.AspNetCore.Mvc;
using ToyData.Repositories;
using System;
using System.Linq;
using ToyWeb.Services;

namespace ToyWeb.Controllers
{
    public class ToyController : Controller
    {
        private readonly IToyRepository toyRepository;
        private readonly IToyService toyService;

        public ToyController(IToyService toyService, IToyRepository toyRepository)
        {
            this.toyService = toyService;
            this.toyRepository = toyRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(toyService.GetToyPage(1));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(toyService.GetToyPage(currentPageIndex));
        }

    }
}
