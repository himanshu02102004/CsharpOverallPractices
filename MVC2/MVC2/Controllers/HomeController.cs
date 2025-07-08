using Microsoft.AspNetCore.Mvc;

namespace MVC2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Account");

            return View();
        }
    }
}
