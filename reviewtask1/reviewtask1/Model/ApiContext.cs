using Microsoft.EntityFrameworkCore;

namespace reviewtask1.Model
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext>options) : base(options)
        {
        }

        public DbSet< Category> categories { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Order>()
        //        .HasMany(o => o.Products)
        //        .WithMany();
        //}
    }
}
