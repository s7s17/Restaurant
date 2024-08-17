using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class MainController : Controller
    {
        public IActionResult index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Event()
        {
            return View();
        }
    }
}
