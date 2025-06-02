

using exercisescrud.Model;

using Microsoft.EntityFrameworkCore;


namespace exercisescrud.Model
{
    public class ApiContext : DbContext
    {

        public readonly ApiContext apiContext;
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<User> user { get; set; }


       
        }


}
