using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PART1.Models;
using MVC_PART1.Services;
using System.Data;

namespace MVC_PART1.Controllers
{

    //filter
    [Roleauthorize(Roles = "Admin,User")]
    public class EventController : Controller
    {
        private readonly AppDbContext _appDbContext;

      

        public EventController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
           
        }







        // GET: /Event
        public async Task<IActionResult> Index()
        {
            var events = await _appDbContext.Events.ToListAsync();
            return View(events);
        }





        // GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public async Task<IActionResult> Create(Event ev)
        {
            if (!ModelState.IsValid)
            {
                return View(ev);
            }
            _appDbContext.Events.Add(ev);
            await _appDbContext.SaveChangesAsync();
            TempData["Success"] = "Event created successfully";
            return RedirectToAction("Index", "Event");

        }








        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ev = await _appDbContext.Events
                        .FirstOrDefaultAsync(m => m.ID == id);

            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }









        ///Delete events

        //public async Task<IActionResult> Deletes(int id)
        //{
        //    var ev = await _appDbContext.Events.FindAsync(id);
        //    return View(ev);

        //}

       
        public async Task<IActionResult> Delete(int id)
        {
            var ev = await _appDbContext.Events.FindAsync(id);

            if (ev == null)
            {
                return NotFound();
            }

            _appDbContext.Events.Remove(ev);
            await _appDbContext.SaveChangesAsync();

            TempData["Success"] = "Event deleted successfully!";
            return RedirectToAction("Index");
        }




        ////EDIT 
        

        public async Task<IActionResult> Edits(int id) {

            var ev = await _appDbContext.Events.FindAsync(id);
            if (ev == null)
                return NotFound();
            return View(ev);

        }


       
        public async Task<IActionResult> Edit(Event ev)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Update(ev);
                await _appDbContext.SaveChangesAsync();
                TempData["Success"] = "Event updated successfully!";
                return RedirectToAction("Index");
            }
            return View(ev);
        }




        /// <param name="disposing"></param>




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _appDbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}