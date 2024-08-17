using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
namespace Restaurant.Controllers
{
    [Authorize(Roles = "Admin")]

    public class MenuItemController : Controller
    {
        private myContext ctx = new myContext();
        public IActionResult Index()
        {
            List<MenuItem> list = ctx.menuItems.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Add()
        {
            MenuItemVM vm = new MenuItemVM() { Categories = new SelectList(ctx.menuCategories.ToList(),"Name","Name") };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Add(MenuItemVM menuItem)
        {
            MenuItem item = new MenuItem()
            {
                Name = menuItem.Name,
                Price = menuItem.Price,
                Image = menuItem.Image,
                Ingredients = menuItem.Ingredients,
                Category = ctx.menuCategories.SingleOrDefault(x => x.Name == menuItem.CategoryName)
            };
            ctx.menuItems.Add(item);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public IActionResult Home()
        {
            List<MenuItem> items = ctx.menuItems.ToList();
            return View(items);
        }
    }
}
