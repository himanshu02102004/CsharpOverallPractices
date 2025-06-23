using Microsoft.AspNetCore.Components.Web;
using MVC_PART1.Models;

namespace MVC_PART1.Services
{
    


        public interface IAccountServices
        {
            bool Login(string username, string password);
            LoginViewControl Login(LoginViewControl model);
            void Register(User user);
        }
    
}
