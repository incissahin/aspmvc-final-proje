using App.Business.Abstract;
using App.Entities.Concrete;
using App.Entities.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userManager;

        public AuthController(IUserService userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            _userManager.TAdd(user);
            return RedirectToAction("Index", "Home");


        }

        public IActionResult Login(string redirectUrl)
        {
            ViewBag.RedirectUrl = redirectUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM model, string? redirectUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userManager.GetUserByEmailAdress(model.Email);

            if (user is null)
            {
                ViewBag.error = "Bu emaille kayıtlı bir kullanıcı bulunamadı.";
                return View(model);
            }
            if (!user.Password.Equals(model.Password))
            {
                ViewBag.error = "Şifre veya Email hatalı...";
                return View(model);
            }
            
            if (user.IsAdmin)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Giriş başarılı ise yönlendirme yapılacak sayfa          
                return RedirectToAction("Index", "Dashboard", new { area = "Admin"});

            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            
            return Redirect(redirectUrl);
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string user)
        {
            return View();
        }

    }

}
