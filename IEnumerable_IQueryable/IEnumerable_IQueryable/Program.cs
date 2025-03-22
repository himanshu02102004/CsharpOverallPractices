using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;        // require for Dbcontext & dbset

namespace IEnumerable_IQueryable
{
    class Program
    {
        static void Main(string[] args)
        {












            // THIS      IS      IQUERYABLE      CODE

            using (var context = new myDbContext())
            {
                IQueryable<User> userquery = context.Users.Where(u => u.Name == "John");
                foreach (var user in userquery)
                {
                    Console.WriteLine(user.Name);
                }
            }




        }
    }



    public class myDbcontext : DbContext
    {
       public DbSet<User> Users { get; set; }
    }


    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
 }















            //THIS      IS      IENUMERABLE      CODE





            //////// IEnumerable executes queries in-memory
          


            //List<int> numbers = new List<int>{1, 2, 3, 4, 5, 6, 7};


               ////OR
              

            //// IEnumerable<int> ints = numbers.GetRange(0, 3);


            ///OR
            


            ////   IEnumerable<int> ints = numbers.Where(n => n > 3);            //  Filters applied after fetching all data into memory.
            //IEnumerable<int> ints = numbers.Where(n => n % 2 == 0);           //The .Where(n => n % 2 == 0) filter is applied afterward.
            //foreach (var i in ints)
            //{
//            //    Console.WriteLine(i);
//            //}
//        }
//    }
//}
