using Microsoft.AspNetCore.Mvc;
using ShopMVC.Data;
using ShopMVC.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ShopMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopMVCContext _context;


        public HomeController(ILogger<HomeController> logger, ShopMVCContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var imageItems = await _context.SliderImage.ToListAsync();
            return View(imageItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}