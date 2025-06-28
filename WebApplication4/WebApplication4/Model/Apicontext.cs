using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Model
{
    public class Apicontext : DbContext
    {
        public Apicontext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
