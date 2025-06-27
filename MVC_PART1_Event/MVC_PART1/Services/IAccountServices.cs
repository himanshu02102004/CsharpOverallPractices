using Microsoft.AspNetCore.Components.Web;
using MVC_PART1.Models;

namespace MVC_PART1.Services
{



    public interface IAccountServices
    {
  
        User Login( Login model);
        IQueryable<User> GetAllUsers();
        void Register(User user);
        

   


    }   }
