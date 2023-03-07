using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClaimBasedAuthorization.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "dotnet")
            {
                var identity = new ClaimsIdentity(new[] { new Claim("UserId", "1") }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                return RedirectToAction("Index", "Home");
            }
            if (username == "raj" && password == "raj")
            {
                var identity = new ClaimsIdentity(new[] { new Claim("UserId", "3") }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);

                return RedirectToAction("Index", "Home");
            }
            if (username == "rishi" && password == "rishi")
            {
                var identity = new ClaimsIdentity(new[] { new Claim("UserId", "50") }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
