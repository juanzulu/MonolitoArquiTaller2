using Microsoft.AspNetCore.Mvc;

namespace MonolitoTaller.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View(); // Opcional si agregas una vista About.cshtml
        }

        public IActionResult Contact()
        {
            return View(); // Opcional si agregas una vista Contact.cshtml
        }
    }
}
