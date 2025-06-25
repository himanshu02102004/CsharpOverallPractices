using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PART1.Models;
using MVC_PART1.Services;
using System.Security.Claims;
using System.Text.Json;
using static MVC_PART1.Services.IAccountServices; 

namespace MVC_PART1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountService;

        public AccountController(IAccountServices accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewControl model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userData = _accountService.Login(model); // Fetch user from DB

            if (userData != null)
            {
                // ✅ Populate Claims for Authentication
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userData.UserName),
            new Claim(ClaimTypes.Role, userData.Role)
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // ✅ Optional: Clear previous login if any
                await HttpContext.SignOutAsync();

                // ✅ Sign in with new identity
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                // ✅ Optional: Store session data
                string sessionObj = JsonSerializer.Serialize(userData);
                HttpContext.Session.SetString("logindetail", sessionObj);

                // ✅ Redirect based on role
                return RedirectToRoleBasedPage(userData);
            }

            // ❌ Invalid credentials
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }









        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewControl model)
        {
            if (!ModelState.IsValid)
                return View("Login", model); // reuse Login view

            var exists = _accountService.GetAllUsers().Any(u => u.UserName == model.UserName);
            if (exists)
            {
                ModelState.AddModelError("", "Username already exists.");
                return View("Login", model);
            }

            var user = new User
            {
                UserName = model.UserName,
                Password = model.Password,
                Name = model.Name,
                Email = model.Email,
                Role = model.Role
            };

            _accountService.Register(user);

            // Log in the user
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, user.Role)
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Event");
        }










        public async Task<IActionResult> Logout()
        {
            //HttpContext.Session.Clear();
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //return RedirectToAction("Login");


            HttpContext.Session.Clear(); // ✅ Clear session
            await HttpContext.SignOutAsync(); // ✅ Clear auth cookie

            return RedirectToAction("Login", "Account");
        }


        private IActionResult RedirectToRoleBasedPage(LoginViewControl vm)
        {
            if (vm.Role == "Admin")
            {
                return RedirectToAction("Index", "Event");
            }
            else if (vm.Role == "User")
            {
                return RedirectToAction("Index", "Event");
            }
            else
            {
                return View("Login");
            }
        }
    }
}
