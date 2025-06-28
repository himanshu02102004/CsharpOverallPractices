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
        public async Task<IActionResult> Login(LoginRegisterWrapper wrapper, string actiontype)
        {
            if (actiontype == "Login")
            {
                var user = _accountService.Login(wrapper.Login);
                if (user != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignOutAsync();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity));

                    TempData["LoginMessage"] = "Successfully logged in!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // ❌ Failure: wrong password or user
                    ModelState.AddModelError("Login.Password", "Invalid username or password.");
                    return View(wrapper);
                }

                
            }



            else if (actiontype == "Register")
            {
                var exists = _accountService.GetAllUsers().Any(u => u.UserName == wrapper.Register.UserName);
                if (exists)
                {
                    ModelState.AddModelError("Register.UserName", "Username already exists.");

                    return View(wrapper);
                }

                var user = new User
                {
                    UserName = wrapper.Register.UserName,
                    Password = wrapper.Register.Password,
                    Name = wrapper.Register.Name,
                    Email = wrapper.Register.Email,
                    Role = wrapper.Register.Role
                };

                _accountService.Register(user);

                // Auto-login
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignOutAsync();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                TempData["RegisterSuccess"] = true;
                return RedirectToAction("Index", "Event");
            }

            return View(wrapper);
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


        private IActionResult RedirectToRoleBasedPage(User user)
        {
            if (user.Role == "Admin" || user.Role == "User")
            {
                return RedirectToAction("Index", "Event");
            }

            return View("Login");
        }

    }
}
