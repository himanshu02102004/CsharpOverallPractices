using Microsoft.EntityFrameworkCore;
using MVC_PART1.Models;
using BCrypt.Net;

namespace MVC_PART1.Services
{
    public class AccountServices :IAccountServices
    {
        private readonly AppDbContext _appDbContext;

        public AccountServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public User Login(Login model)
        {
            var user = _appDbContext.Users.FirstOrDefault(u => u.UserName == model.UserName);

            if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return user; // Successful login
            }

            return null; // Login failed
        }



        // ✅ Used for checking duplicate username during registration
        public IQueryable<User> GetAllUsers()
        {
            return _appDbContext.Users.AsQueryable();
        }

        // ✅ Used in controller Register action
        public void Register(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
           

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }
    }
}
 