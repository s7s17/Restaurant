using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Restaurant.Controllers
{
    public class BookingController : Controller
    {
        private myContext myContext = new myContext();
        [HttpGet]
        public IActionResult BookTable()
        {
            BookingVM bookingVM = new BookingVM() { Tables =new SelectList(myContext.Table.ToList(), "TableNumber", "TableNumber") };
            return View(bookingVM);
        }

        [HttpPost]
        public IActionResult BookTable(BookingVM table)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            Table tbl = myContext.Table.Single(t => t.TableNumber == table.TableNum);
            BookedTable booked = myContext.BookedTable.SingleOrDefault(t => t.TableNum == table.TableNum && t.BookDate == table.BookDate);
            if (booked != null)
            {
                ModelState.AddModelError("", "This table is Already booked in that date");
                BookingVM bookingVM = new BookingVM() { Tables = new SelectList(myContext.Table.ToList(), "TableNumber", "TableNumber") };
                return View(bookingVM);
            }
            booked = new BookedTable();
            booked.UserID = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value;
            booked.Message = table.Message;
            booked.TableNum = table.TableNum;
            booked.BookDate = table.BookDate;
            booked.NumOfPersons = table.NumOfPersons;
            booked.BookTime = table.BookTime;
            myContext.BookedTable.Add(booked);
            myContext.SaveChanges();
            TempData["Booked"] = "Done. We will be waiting for you.";
            return RedirectToAction("index","Main");
        }
    }
}
