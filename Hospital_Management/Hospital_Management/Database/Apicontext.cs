using Hospital_Management.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Database
{
    public class Apicontext : DbContext
    {
        public Apicontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Appointment> appointments { get; set; }

        
    }
}
