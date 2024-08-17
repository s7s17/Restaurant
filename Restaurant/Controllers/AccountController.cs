using Restaurant.Models;
using Restaurant.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.usermanager = userManager;
            this.signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await usermanager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    bool valid = await usermanager.CheckPasswordAsync(user, loginVM.Password);
                    if (valid) 
                    {
                        List<Claim> claim = new List<Claim>() {new Claim ("Email", user.Email) };
                        await signInManager.SignInWithClaimsAsync(user, loginVM.RememberMe,claim);
/*                        await signInManager.SignInAsync(user, loginVM.RememberMe);
*/                        return RedirectToAction("Index", "Main");
                    }
                }
                ModelState.AddModelError("", "Wrong Email Or Password");
                return View(loginVM);
            }
            return View(loginVM);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync(); 
            return RedirectToAction("Index", "Main");
        }
    }
}
