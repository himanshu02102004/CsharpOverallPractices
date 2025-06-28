using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Model
{
    public class Apicontext : DbContext
    {
        public Apicontext(DbContextOptions<Apicontext>  options) : base(options)
        {
        }

       public DbSet<Category> categories { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }




    }
}
