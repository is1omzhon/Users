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
        foreach (User item in _users)
        {
            if (item.Id == id)
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
            Email : {user.Email}
            Address : {user.Address}
            """
        );
    }

    public void UpdateUser(User user)
    {
        var findUser = _users.Find(u => u.Id == user.Id);
        if (findUser == null) return;

        findUser.FIO = user.FIO;
        findUser.Email = user.Email;
        findUser.Address = user.FIO;
        findUser.PhoneNmber = user.PhoneNmber;
        Console.WriteLine("User Updated");
    }

    public void DeleteUser(int id)
    {
        if (_users.RemoveAll(u => u.Id == id) == 0)
            Console.WriteLine("User topilmadi");

        else Console.WriteLine("User deleted!");
    }

}