using Users.Models;
using Users.Services;

public class UserService : IUserService
{
    private List<User> _users;

    public UserService()
    {
        this._users = new List<User>();
    }

    public void CreateUser(User user)
    {
        _users.Add(user);
        Console.WriteLine($"{user.FIO} qo'shildi");
    }
}