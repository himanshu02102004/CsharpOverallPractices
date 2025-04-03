 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESCOREBASICS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ESCOREBASICS.Data
{

    
    ///  DBContext class
    

    public  class AppDbContext: DbContext
    {
        public DbSet <Employee>  Employees{ get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }




        public string  ConnectionString { get; }

        public AppDbContext()
        {
            ConnectionString = " Data Source =(localdb)\\MSSqlLocalDB;Initial Catalog =EmployeeMngt_EFCorePractice;Integrated Security =True";

           

        }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()
        //        .HasOne(e => e.EmployeeDetails)
        //        .WithOne(d => d.Employee)
        //        .HasForeignKey<EmployeeDetails>(d => d.EmployeeId);
        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            

            optionsBuilder.UseSqlServer(ConnectionString);


        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmployeeProject>()
        //        .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });



        //    modelBuilder.Entity<EmployeeProject>()
        //        .HasOne(ep => ep.Employee)
        //        .WithMany(e => e.EmployeeProjects)
        //        .HasForeignKey(ep => ep.EmployeeId);


        //    modelBuilder.Entity<EmployeeProject>()
        //        .HasOne(ep => ep.Project)
        //        .WithMany(e => e.EmployeeProjects)
        //        .HasForeignKey(ep => ep.ProjectId);
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Employee to EmployeeDetails relationship (One-to-One)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.EmployeeDetails)
                .WithOne(d => d.Employee)
                .HasForeignKey<EmployeeDetails>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Ensures cascading delete









            // Configure Employee to Project (Many-to-Many)
            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);
        }




    }
}
