using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_PART1.Filters;
using MVC_PART1.Models;

namespace MVC_PART1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    //   [ExceptionCheck]

    [MvcAuthorization]
    public ActionResult Index()
    {
         //throw new NotImplementedException();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
