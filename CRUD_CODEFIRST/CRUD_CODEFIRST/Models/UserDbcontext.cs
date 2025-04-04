
using Microsoft.EntityFrameworkCore;

namespace CRUD_CODEFIRST.Models
{
    public class UserDbcontext : DbContext
    {
        public UserDbcontext(DbContextOptions options ) : base(options)
        {
            
        }

        public DbSet <User> Users { get; set;    }

    }
}
