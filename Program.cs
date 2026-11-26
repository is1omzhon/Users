using Users.Models;
using Users.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        IUserService userService = new UserService();
        User newUser = new User
        {
            Id = 1,
            Address = "Uzbekistan, Namangan",
            Email = "user@gmail.com",
            FIO = "Alisher Nosirov Umarovich",
            PhoneNmber = "+998935678844",
        };

        User user2 = new User
        {
            Id = 2,
            Address = "Uzbekistan, Tashkent",
            Email = "user@dotnet.uz",
            FIO = "Abror Toshev Usmonovich",
            PhoneNmber = "+998901234545",
        };

        userService.CreateUser(newUser);
        userService.CreateUser(user2);

        User storageUser = userService.GetUserById(2);
        if (storageUser != null)
        {
            userService.Print(storageUser);
        }
        else
        {
            Console.WriteLine("User topilmadi");
        }

        User updetedUser = new User
        {
            Id = 1,
            Address = "Uzbekistan",
            Email = "Test@uz.com",
            FIO = "Akmal Qodirov Saidovich",
            PhoneNmber = "+998887777777"
        };

        userService.UpdateUser(updetedUser);
        userService.Print(newUser);

        userService.DeleteUser(2);
        var isDeletesUser = userService.GetUserById(2);

        // Tekshirish uchun
        if (isDeletesUser != null)
        {
            userService.Print(isDeletesUser);
        }
        else
        {
            Console.WriteLine("User topilmadi");
        }

    }
}
