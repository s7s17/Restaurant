using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MenuCatController : Controller
    {
        private myContext ctx = new myContext();
        public IActionResult Index()
        {
            List<MenuCategory> list = ctx.menuCategories.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MenuCategory category)
        {
            ctx.menuCategories.Add(category);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            MenuCategory category = ctx.menuCategories.Single(x => x.Id == id);
            ctx.menuCategories.Remove(category);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
