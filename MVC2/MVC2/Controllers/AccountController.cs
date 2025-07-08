using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using MVC2.Services;

namespace MVC2.Controllers
{
    public class AccountController : Controller
    {
        private static List<User> users = new(); // In-memory store
        private readonly JwtService _jwtService;

        public AccountController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            var exists = users.Any(u => u.Username == user.Username);
            if (exists)
            {
                ViewBag.Message = "User already exists";
                return View();
            }

            users.Add(user);
            return RedirectToAction("Login");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(User user)
        {
            var valid = users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (valid == null)
            {
                ViewBag.Message = "Invalid credentials";
                return View();
            }

            var token = _jwtService.GenerateToken(user.Username);
            HttpContext.Session.SetString("JWTToken", token);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
