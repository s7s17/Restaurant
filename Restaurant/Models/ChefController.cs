using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Models
{
    public class ChefController : Controller
    {
        private myContext ctx = new myContext();
        public IActionResult Index()
        {
            List<Chef> chefList = ctx.Chefs.ToList();
            return View(chefList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Chef chef) 
        { 
            ctx.Chefs.Add(chef);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Chef chef = ctx.Chefs.Single(c => c.Id == id);
            return View(chef);
        }
        [HttpPost]
        public IActionResult Edit(int id, Chef chef)
        {
            Chef chef1 = ctx.Chefs.Single(che => che.Id == id);
            chef1.Position = chef.Position;
            chef1.Name = chef.Name;
            chef1.Description = chef.Description;
            chef1.Image = chef.Image;
            chef1.HireDate = chef.HireDate;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Chef chef1 = ctx.Chefs.Single(che => che.Id == id);
            ctx.Chefs.Remove(chef1);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Home()
        {
            List<Chef> chefs = ctx.Chefs.ToList();
            return View(chefs);
        }
    }
}
