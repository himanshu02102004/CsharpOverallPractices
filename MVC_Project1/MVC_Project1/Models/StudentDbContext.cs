using Microsoft.EntityFrameworkCore;

namespace MVC_Project1.Models
{
    public class StudentDbContext: DbContext
    {

        public StudentDbContext( DbContextOptions options) : base(options)
        {
            
        }


        public DbSet <student > students { get; set; }
    }
}
