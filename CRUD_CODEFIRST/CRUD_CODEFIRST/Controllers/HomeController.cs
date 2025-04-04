using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUD_CODEFIRST.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CRUD_CODEFIRST.Controllers;

public class HomeController : Controller
{

    // this is code for userdb


    //private readonly UserDbcontext userDb;
   

    ////private readonly ILogger<HomeController> _logger;

    ////public HomeController(ILogger<HomeController> logger)
    ////{
    ////    _logger = logger;
    ////}



    //public HomeController( UserDbcontext UserDb)
    //{
    //    this.userDb = UserDb;          //// homecontroller ke aandar inject kar diya
    //}






    //public async Task <IActionResult> Index()
    //{


    //    var stddata =   await userDb.Users.ToListAsync();
    //    return View(stddata);
    //}





    //public IActionResult Create()
    //{
    //    return View();
    //}




    //[HttpPost]
    //public  async Task <IActionResult> Create(User usr)
    //{

    //    if (ModelState.IsValid)
    //    {
    //       await userDb.Users.AddAsync(usr);
    //        await userDb.SaveChangesAsync();
            
    //        return RedirectToAction("Index", "Home"); 
    //    }

    //    return View(usr);
    //}






    //public async Task<IActionResult> Details(int ? id)
    //{
    //    if(id==null || userDb.Users == null)
    //    {
    //        return NotFound();
    //    }

    //    var stddata = await userDb.Users.FirstOrDefaultAsync(x => x.Id == id);


    //    if(stddata == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(stddata);
    //}








    //// EDIT 






    //public async Task<IActionResult> Edit(int ? id)
    //{


    //    if (id == null || userDb.Users == null)
    //    {
    //        return NotFound();
    //    }

    //    var stddata = await userDb.Users.FindAsync(id);

    //    if (stddata == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(stddata);
    //}


    //[HttpPost]
    //public async Task <IActionResult> Edit(int? id,User usr)
    //{
    //    if(id != usr.Id)
    //    {
    //        return NotFound();
    //    }


    //    if (ModelState.IsValid)
    //    {
    //         userDb.Users.Update(usr);
    //        await userDb.SaveChangesAsync();
    //        return RedirectToAction("Index", "Home");
    //    }

    //    return View(usr);
    //}








    ///// Delete


    //public  async Task< IActionResult> Delete( int  ? id)
    //{

    //    if (id == null || userDb.Users == null)
    //    {
    //        return NotFound();
    //    }



    //    var stddata = await userDb.Users.FirstOrDefaultAsync(x => x.Id == id);



    //    if (stddata == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(stddata);
    //}



    //[HttpPost,ActionName("Delete")]
    //public async Task<IActionResult> DeleteConfirmed(int? id)
    //{

    //    var stddata = await userDb.Users.FindAsync(id);
    //    if(stddata != null)
    //    {
    //        userDb.Users.Remove(stddata);
    //    }

    //    await userDb.SaveChangesAsync();
    //    return RedirectToAction("Index", "Home");
    //}





    ///// <summary>
    /////  this is for product
    ///// </summary>


    private readonly PropDbcontext propDbcontext;
    public HomeController(PropDbcontext propDbcontext)
    {
        this.propDbcontext = propDbcontext;
    }


    public async Task<IActionResult> Index1()
    {


        var stddatas = await propDbcontext.Products.ToListAsync();
        return View(stddatas);
    }



    public IActionResult Create1()
    {
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
