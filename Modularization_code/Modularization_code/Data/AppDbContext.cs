using Microsoft.EntityFrameworkCore;
using Modularization_code.Model;

namespace Modularization_code.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Product>().ToTable("Products");
            base.OnModelCreating(modelBuilder);
        }
    }
   
}
