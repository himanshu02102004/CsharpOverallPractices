using Microsoft.EntityFrameworkCore;

namespace task.Model
{
    public class Apicontext : DbContext
    {

        public readonly Apicontext apicontext;
        public  Apicontext(DbContextOptions<Apicontext> options) : base(options)
            {
            this.apicontext = apicontext;
               
            

             }

        public DbSet<Customer> customers { get; set; }


      
    }
}
