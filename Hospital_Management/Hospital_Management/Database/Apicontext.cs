using Microsoft.EntityFrameworkCore;

namespace Hospital_Management.Database
{
    public class Apicontext : DbContext
    {
        public Apicontext(DbContextOptions options) : base(options)
        {
        }

        
    }
}
