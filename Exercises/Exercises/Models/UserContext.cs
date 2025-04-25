using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Exercises.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)

        {

        }

        public DbSet<User> users{get; set;} 
    }
}
