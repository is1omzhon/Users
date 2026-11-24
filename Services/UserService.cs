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

    public User GetUserById(int id)
    {
        foreach(User item in _users)
        {
            if(item.Id == id)
            {
                return item;
            }
            
        }

        return null;   
    }

    public void Print(User user)
    {
        Console.WriteLine
        (
            $""" 
            Id: {user.Id}, 
            FIO : {user.FIO}
            """
        );
    }
}