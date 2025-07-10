using Azure.Identity;
using Hospital_Management.Database;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace Hospital_Management.Model
{
    public class DataInitializers
    {

        public static void SetAdmin(Apicontext apicontext)
        {
            if(!apicontext.Users.Any(u => u.Role == "Admin"))
            {
                var admin = new User
                {
                    User_Name = "admin",
                    User_Password=BCrypt.Net.BCrypt.HashPassword("admin@123"),
                    Role= "admin"
                }; 

                apicontext.Users.Add(admin);
                apicontext.SaveChanges();


            }


        }
    }
}
