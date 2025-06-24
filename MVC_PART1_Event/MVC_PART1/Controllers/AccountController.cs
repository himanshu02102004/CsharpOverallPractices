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
        public async Task<IActionResult> Login(LoginViewControl model, string actiontype)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (actiontype == "Register")
            {
                var existingUser = _accountService.GetAllUsers()
                    .FirstOrDefault(u => u.UserName == model.UserName);

                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Username already exists.");
                    return View(model);
                }

                // ✅ Create and register new user
                var newUser = new User
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    Name = model.Name,
                    Role = model.Role,
                    Email = model.Email // ✅ make sure this is collected from the form
                };

                _accountService.Register(newUser);

                // ✅ Automatically log in the newly registered user
                model.UserId = newUser.ID;

                // Store in session
                string sessionObj = JsonSerializer.Serialize(model);
                HttpContext.Session.SetString("logindetail", sessionObj);

                // Create auth cookie
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.UserName),
            new Claim(ClaimTypes.Role, model.Role)
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToRoleBasedPage(model);
            }

            // LOGIN section
            LoginViewControl vm = _accountService.Login(model);
            if (vm != null)
            {
                string sessionObj = JsonSerializer.Serialize(vm);
                HttpContext.Session.SetString("logindetail", sessionObj);

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, vm.UserName),
            new Claim(ClaimTypes.Role, vm.Role)
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToRoleBasedPage(vm);
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }










        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


        private IActionResult RedirectToRoleBasedPage(LoginViewControl vm)
        {
            if (vm.Role == "Admin")
            {
                return RedirectToAction("Index", "Event");
            }
            else if (vm.Role == "User")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Login");
            }
        }
    }
}
