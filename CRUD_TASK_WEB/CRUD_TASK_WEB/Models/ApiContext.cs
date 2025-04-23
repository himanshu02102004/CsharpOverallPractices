using CRUDTASK_CODE.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CRUD_TASK_WEB.Models
{
    public class ApiContext : DbContext
    {
        public readonly ApiContext apiContext;
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
              .HasKey(c => c.CategoryId); // Explicitly set PK

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);




            modelBuilder.Entity<Users>().HasQueryFilter(u => !u.IsDeleted);

            base.OnModelCreating(modelBuilder);

        }

    }
}

