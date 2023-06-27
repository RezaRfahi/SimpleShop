using Microsoft.AspNetCore.Mvc;

namespace MVCShop.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
