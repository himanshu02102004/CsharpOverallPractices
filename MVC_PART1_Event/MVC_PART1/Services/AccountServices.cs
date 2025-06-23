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
        throw new NotImplementedException();
    }

    public void Register(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        _appDbContext.Users.Add(user);
        _appDbContext.SaveChanges();
    }
}
