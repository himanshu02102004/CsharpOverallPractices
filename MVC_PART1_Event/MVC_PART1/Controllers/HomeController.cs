
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_PART1.Filters;

//using MVC_PART1.Filters;
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

    //  [MvcAuthorization]
    //[Authorize]
    //public ActionResult Index()
    //{
    //     //throw new NotImplementedException();
    //    return View();
    //}

    //[Authorize]
    //public IActionResult Index()
    //{
    //    return View();
    //}

    // [Authorize]



    [AuthorizeSession]
    public IActionResult Index()
    {
        Console.WriteLine("🔐 IsAuthenticated: " + User.Identity.IsAuthenticated);
        Console.WriteLine("👤 Name: " + User.Identity.Name);

        foreach (var claim in User.Claims)
        {
            Console.WriteLine($"📛 Claim: {claim.Type} = {claim.Value}");
        }

        return View();
    }






    //[Authorize]
    //[HttpGet("api/securedata")]
    //public IActionResult GetSecureData()
    //{
    //    return Ok(new { message = "You are authenticated!" });
    //}



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
