using Microsoft.AspNetCore.Mvc;
using MVC_PART1.Models;
using MVC_PART1.Services;
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
        public IActionResult Login(LoginViewControl model)
        {
           

            LoginViewControl vm = _accountService.Login(model);
            if (vm != null)
            {
                // Store user info in session
                string sessionobj=JsonSerializer.Serialize(vm);
                HttpContext.Session.SetString("logindetail", sessionobj);

                return RedirectToRoleBasedPage(vm);
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
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
