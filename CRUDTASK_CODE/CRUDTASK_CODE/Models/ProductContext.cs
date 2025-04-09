using Microsoft.EntityFrameworkCore;

namespace CRUDTASK_CODE.Models
{
    public class ProductContext:DbContext
    {   

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
       
         

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
              .HasKey(c => c.CategoryId); // Explicitly set PK

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            base.OnModelCreating(modelBuilder);

        }

        }
    }
