using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize] //are u allowed to come heres?
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                //sign-in user here
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Register(string userName, string password)
        {
            var user = new IdentityUser()
            {
                UserName = userName,
            };

            var response = await _userManager.CreateAsync(user, password);

            if (response.Succeeded)
            {
                //sign-in user here
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
