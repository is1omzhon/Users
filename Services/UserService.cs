using Users.Models;
using Users.Services;

public class UserService : IUserService
{
    private List<User> _users;

    public UserService(List<User> users)
    {
        this._users = users;
    }

    public void CreateUser(string name, string email)
    {
        throw new NotImplementedException();
    }
}