using MVC_PART1.Models;

namespace MVC_PART1.Services;

public class AccountServices: IAccountServices
{

    private readonly AppDbContext _appDbContext;
    public AccountServices(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public bool Login(string username, string password)
    {
        var user = _appDbContext.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        return user != null;
    }

    public LoginViewControl Login(LoginViewControl model)
    {
        var user = _appDbContext.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

        if (user != null)
        {
            return new LoginViewControl
            {
                UserName = user.UserName,
                Role = user.Role,
                UserId = user.ID
            };
        }

        return null;
    }


    public IQueryable<User> GetAllUsers()
    {
        return _appDbContext.Users.AsQueryable();
    }



    public void Register(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        Console.WriteLine("Registering user with role: " + user.Role);
        _appDbContext.Users.Add(user);
        _appDbContext.SaveChanges();
    }
}
