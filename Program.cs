using Users.Models;
using Users.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        IUserService userService = new UserService();
        User newUser = new User
        {
            Id = 01,
            Address = "Uzbekistan, Namangan",
            Email = "user@gmail.com",
            FIO = "Alisher Nosirov Umarovich",
            PhoneNmber = "935678844",
        };

        userService.CreateUser(newUser);
        User storageUser = userService.GetUserById(2);
        if (storageUser != null)
        {
            userService.Print(storageUser);   
        }
        else
        {
            Console.WriteLine("User topilmadi");
        }
    }
}
