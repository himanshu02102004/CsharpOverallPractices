using Microsoft.EntityFrameworkCore;

namespace CRUDTASK_CODE.Models
{
    public class UserContrext: DbContext
    {

        public UserContrext(DbContextOptions <UserContrext>options): base(options)
        
        {
            

        }

        public DbSet<Users> Users{ get; set; }
    }
}
