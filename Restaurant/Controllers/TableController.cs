using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Authorize(Roles = "Admin")]

    public class TableController : Controller
    {
        private myContext ctx = new myContext();
        public IActionResult Index()
        {
            List<Table> tables = ctx.Table.ToList();
            return View(tables);
        }
        public IActionResult Delete(string tablenum)
        {
            Table table = ctx.Table.SingleOrDefault(t => t.TableNumber == tablenum);
            if (table != null)
            {
                ctx.Table.Remove(table);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string tablenum)
        {
            Table table = ctx.Table.SingleOrDefault( t => t.TableNumber == tablenum );
            return View(table);
        }
        [HttpPost]
        public IActionResult Edit( Table table)
        {
            Table _table =ctx.Table.SingleOrDefault(t => t.TableNumber == table.TableNumber);
            _table.TableCapacity = table.TableCapacity;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
            { return View(); }

        [HttpPost]
        public IActionResult Add(Table table)
        {
            ctx.Table.Add(table);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
