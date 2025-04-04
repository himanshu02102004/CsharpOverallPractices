using Microsoft.EntityFrameworkCore;

namespace CRUD_CODEFIRST.Models
{
    public class PropDbcontext : DbContext
    {
        public PropDbcontext(DbContextOptions <PropDbcontext>options) : base(options)
        {


        }
        public DbSet<Product> Products { get; set; }
       
    }
}
