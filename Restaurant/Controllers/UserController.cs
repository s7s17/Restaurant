using Restaurant.Models;
using Restaurant.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager ,SignInManager<ApplicationUser> signInManager)
        { 
            this.usermanager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {
            
            List<ApplicationUser> data = usermanager.Users.ToList();
            List<RegistrationVM> users = new List<RegistrationVM>();

            foreach (var item in data)
            {
                users.Add(new RegistrationVM()
                {
                    UserName = item.UserName,
                    Email = item.Email,
                    Address = item.Address,
                    Age = item.Age,
                    RegisterDate = item.RegisterDate,
                    PhoneNumber = item.PhoneNumber
                });
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult Regestration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Regestration(RegistrationVM registration)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usr = new ApplicationUser()
                {
                    UserName = registration.UserName,
                    Email = registration.Email,
                    Address = registration.Address,
                    Age = registration.Age,
                    RegisterDate = DateTime.Now,
                    PhoneNumber = registration.PhoneNumber
                };
                IdentityResult result = await usermanager.CreateAsync(usr,registration.Password);                
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(usr, true);
                    await usermanager.AddToRoleAsync(usr, "Client");                   
                     return RedirectToAction("index", "Main");                                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registration);
            }
            return View(registration);
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult AddUserToRole()
        {
            UserToRoleVM userToRoles = new UserToRoleVM()
            {
                Users = new SelectList(usermanager.Users.ToList(), "Id", "UserName"),
                Roles = new SelectList(roleManager.Roles.ToList(), "Name", "Name")
            };
            return View(userToRoles);
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserToRoleVM userToRole)
        { 
            ApplicationUser user = await usermanager.FindByIdAsync(userToRole.UserID);
            IdentityResult result = await usermanager.AddToRoleAsync(user,userToRole.RoleName);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(); 
        }

    }
}
