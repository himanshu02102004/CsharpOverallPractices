
using Microsoft.EntityFrameworkCore;





namespace MVC_PART1.Models
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {


        } 

        public DbSet<Event> Events { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<EventRegistration> EventsRegistration { get; set; }
       
    }
}
