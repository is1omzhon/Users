namespace Users.Services;

using Users.Models;

public class UserService : IUserService
{
    private List<User> _users;

    public UserService()
    {
        this._users = new List<User>();
    }

    public void CreateUser(User user)
    {
        if (user == null)
        {
            Console.WriteLine("Xato: User bo'sh bulmasligi kerak!");
            return;
        }

        if (user.Id <= 0)
        {
            Console.WriteLine("Xato: Id musbat son bo'lish kerak!");
            return;
        }

        if (string.IsNullOrWhiteSpace(user.Name))
        {
            Console.WriteLine("Xato: User bo'sh bulmasligi kerak!");
            return;
        }

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            Console.WriteLine("Xato: Email bo'sh bulmasligi kerak!");
            return;
        }

        if (string.IsNullOrWhiteSpace(user.PhoneNumber))
        {
            Console.WriteLine("Xato: User bo'sh bulmasligi kerak!");
            return;
        }

        if (user.Age <= 0 || user.Age > 150)
        {
            Console.WriteLine("Xato: Age 1 dan 150gacha  bulishi kerak!");
            return;
        }

        if (_users.Any(u => u.Id == user.Id))
        {
            Console.WriteLine("Xato: bunday Id li user allaqachon mavjud.");
            return;
        }

        if (_users.Any(u => u.Email == user.Email))
        {
            Console.WriteLine("Xato: bunday email li user allaqachon mavjud.");
            return;
        }

        _users.Add(new User
        {
            Id = user.Id,
            Name = user.Name,
            Age = user.Age,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        });

        Console.WriteLine($"{user.Name} muvaffaqiyatli qushildi!");
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

    public void PrintUser(User user)
    {
        if(user == null)
        {
            Console.WriteLine("Xato: User bosh bulmasligi kerak!");
            return;    
        }

        Console.WriteLine
        (
            $""" 
            Id : {user.Id}
            FIO : {user.Name}
            Age : {user.Age}
            Email : {user.Email}
            Phone : {user.PhoneNumber}
            """
        );
    }

    public User[] GetAllUsers()
    {
        User[] result = new User[_users.Count];

        for (int i = 0; i < _users.Count; i++)
        {
            User user = _users[i];

            result[i] = new User
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }

        return result;
    }

    public void UpdateUser(User user)
    {
        var findUser = _users.Find(u => u.Id == user.Id);
        if (findUser == null) return;

        findUser.Name = user.Name;
        findUser.Age = user.Age;
        findUser.Email = user.Email;
        findUser.PhoneNumber = user.PhoneNumber;
        Console.WriteLine("User Updated");
    }

    public void DeleteUser(int id)
    {
        if (_users.RemoveAll(u => u.Id == id) == 0)
            Console.WriteLine("User topilmadi");

        else Console.WriteLine("User deleted!");
    }
}