using Microsoft.AspNetCore.Mvc;

namespace MonolitoTaller.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
