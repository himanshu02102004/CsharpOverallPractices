  
using Microsoft.EntityFrameworkCore;

namespace MVC_PART1.Models
{
    public class AppDbContext : DbContext 
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {


        }

        

        public DbSet<Event> Events { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<EventRegistration> EventsRegistration { get; set; }

       


        internal async Task FindAsync(int id)
        {
            throw new NotImplementedException();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasData
                (new User { ID = 1, Name = " Admin ", Role = 1, UserName = "Admin" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
