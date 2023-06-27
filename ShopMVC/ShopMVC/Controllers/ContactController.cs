using Microsoft.AspNetCore.Mvc;

namespace MVCShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

       [HttpPost]
        public IActionResult Submit(ContactFormModel formModel)
        {
            // Process the form submission, send email, save to database, etc.

            // Optionally, redirect to a thank you page
            return RedirectToAction("ThankYou");
        }
        
}
