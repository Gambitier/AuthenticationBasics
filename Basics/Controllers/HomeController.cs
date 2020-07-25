using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Basics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize] //are u allowed to come heres?
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var localAuthorityClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Akash"),
                new Claim(ClaimTypes.Email, "akash.jadhav.cse@gmail.com"),
                new Claim("Nickname", "gambitier")
            };

            var licenceAuthorityClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Akash.Laxman.Jadhav"),
                new Claim(ClaimTypes.Email, "csegambitier@gmail.com"),
                new Claim("Nickname", "AJ"),
                new Claim("Licence.Number", "IN9763714604")
            };

            var localAuthorityIdentity = new ClaimsIdentity(localAuthorityClaims, "Local Authority's Identity");

            var licenceAuthorityIdentity = new ClaimsIdentity(licenceAuthorityClaims, "Liecence Authority's Identity");

            var appAuthenticationPrincipal = new ClaimsPrincipal(new[] { localAuthorityIdentity, licenceAuthorityIdentity });

            HttpContext.SignInAsync(appAuthenticationPrincipal);

            return RedirectToAction("Index", "Home");
        }
    }
}
