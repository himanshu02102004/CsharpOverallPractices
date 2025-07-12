using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace test1.Model
{
    public class ApiContext:DbContext
    {
        private readonly ApiContext _context;
        public ApiContext(DbContextOptions<ApiContext> options): base(options)
        {
          
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
