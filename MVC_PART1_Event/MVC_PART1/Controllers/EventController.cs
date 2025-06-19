
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_PART1.Models;



namespace MVC_PART1.Controllers
{
    public class EventController : Controller

    {

        private readonly AppDbContext _appDbContext;
        public EventController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //GET: /Event
        public IActionResult Index() {

            var Events = _appDbContext.Events.ToList();
            return View(Events);

        }


        //Event Created

        public IActionResult Create() {

            return View();

        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event ev) {

            if (ModelState.IsValid) {

                _appDbContext.Events.Add(ev);
                _appDbContext.SaveChanges();
                TempData["Success"] = "Event created Successfully";
                return RedirectToAction();


            }

            return View();
        }

        /// id get detail
        

        [HttpGet]
        public IActionResult Register(int Id)
        {
            var er = _appDbContext.Users.Find(Id);

            if (er != null)
            {
                return NotFound();
            }
            return View(er);
        }





        //post events/registrer/id

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(int id, string email) {

            var user = _appDbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                TempData["Error"] = "User is not found";
                return RedirectToAction(nameof(Register), new { id });

            }
            var alreadyregistered = _appDbContext.EventsRegistration.Any(r => r.EventId == id && r.UserId == user.ID);

            if (alreadyregistered)
            {
                TempData["Eror"] = "Already registrered";
                return RedirectToAction(nameof(Register), new { id });

            }

            _appDbContext.EventsRegistration.Add(new EventRegistration { EventId = id, UserId = user.ID });
            _appDbContext.SaveChanges();
            TempData["Success"] = "Registration succesfull";
            return RedirectToAction(nameof(Index));
   }




       
        public IActionResult Details(int id) {

            var ev = _appDbContext.Events
                                .Include(e => e.Registrations.Select(r=>r.Users))
                                .FirstOrDefault(User => User.ID == id);
            if(ev== null)
            {
                return NotFound();
            }
                                
                               
          return View(ev);
            

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _appDbContext.Dispose(); // Release the DbContext and its resources
            }
            base.Dispose(disposing); // Call the base Controller's Dispose method
        }


    }
}
