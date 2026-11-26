using Users.Models;

namespace Users.Services;

public interface IUserService
{
    void CreateUser(User user);
    User GetUserById(int id);
    void UpdateUser(User user);
    void DeleteUser(int id);
    void PrintUser(User user);
    User[] GetAllUsers();
}
