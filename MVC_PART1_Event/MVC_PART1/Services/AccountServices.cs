using Microsoft.EntityFrameworkCore;
using MVC_PART1.Models;

namespace MVC_PART1.Services
{
    public class AccountServices :IAccountServices
    {
        private readonly AppDbContext _appDbContext;

        public AccountServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // ✅ Used in controller Login action to verify credentials
        public LoginViewControl Login(LoginViewControl model)
        {
            var user = _appDbContext.Users.FirstOrDefault(u =>
                u.UserName == model.UserName && u.Password == model.Password);

            if (user != null)
            {
                return new LoginViewControl
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Role = user.Role,
                    Name = user.Name,
                    Email = user.Email,
                    UserId = user.ID
                };
            }

            return null;
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

            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }
    }
}
 