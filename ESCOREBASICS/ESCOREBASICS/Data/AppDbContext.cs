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


        public string  ConnectionString { get; }

        public AppDbContext()
        {
            ConnectionString = " Data Source =(localdb)\\MSSqlLocalDB;Initial Catalog =EmployeeMngt_EFCorePractice;Integrated Security =True";

           

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            

            optionsBuilder.UseSqlServer(ConnectionString);


        }


    }
}
