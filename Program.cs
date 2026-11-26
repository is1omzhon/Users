using System.Net;
using Users.Models;
using Users.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        IUserService userService = new UserService();

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("========================");
            Console.WriteLine(" USER SERVICE MENU");
            Console.WriteLine("========================");
            Console.WriteLine("1. Foydalanuvchi yaratish");
            Console.WriteLine("2. ID orqali ko‘rish");
            Console.WriteLine("3. Barcha foydalanuvchilarni ko‘rish");
            Console.WriteLine("4. Foydalanuvchini yangilash");
            Console.WriteLine("5. Foydalanuvchini o‘chirish");
            Console.WriteLine("0. Chiqish");
            Console.WriteLine("========================");
            Console.WriteLine("Tanlang:");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Raqam kiriting!");
                Thread.Sleep(5000);
                Console.Clear();
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateUserAction(userService);
                    break;

                case 2:
                    GetByIdAction(userService);
                    break;

                case 3:
                    GetAllAction(userService);
                    break;

                case 4:
                    UpdateUserAction(userService);
                    break;

                case 5:
                    DeleteUserAction(userService);
                    break;

                case 0:
                    isRunning = false;
                    continue;

                default:
                    Console.WriteLine("Notugri tanlov!");
                    break;
            }
        } ;
    }

    static void CreateUserAction(IUserService userService)
    {
        Console.Write("ID:");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID butun son bulish kerak!");
            return;
        }

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Ages: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Age butun son bulish kerak!");
            return;
        }

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("PhoneNumber: ");
        string phoneNumber = Console.ReadLine();

        var user = new User
        {
            Id = id,
            Name = name,
            Age = age,
            Email = email,
            PhoneNumber = phoneNumber
        };

        userService.CreateUser(user);
    }
    static void GetByIdAction(IUserService userService)
    {
        Console.Write("ID:");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID butun son bo'lishi kerak.");
            return;
        }

        User storageUser = userService.GetUserById(id);
        if (storageUser != null)
        {
            userService.PrintUser(storageUser);
        }
        else
        {
            Console.WriteLine("User topilmadi");
        }

    }
    static void GetAllAction(IUserService userService)
    {
        User[] users = userService.GetAllUsers();

        if (users.Length == 0)
        {
            Console.WriteLine("Foydalanuvchilar yuq!");
            return;
        }

        foreach (User user in users)
        {
            userService.PrintUser(user);
            Console.WriteLine();
        }

    }
    static void UpdateUserAction(IUserService userService)
    {
        Console.Write("Yangilanadigan user ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID butun son bo'lishi kerak.");
            return;
        }

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Age: ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Age butun son bo'lishi kerak.");
            return;
        }

        Console.Write("Phone number: ");
        string phoneNumber = Console.ReadLine();

        var updatedUser = new User
        {
            Id = id,
            Name = name,
            Email = email,
            Age = age,
            PhoneNumber = phoneNumber
        };

        userService.UpdateUser(updatedUser);
    }
    static void DeleteUserAction(IUserService userService)
    {
        Console.Write("User ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID butun son bo'lishi kerak.");
            return;
        }

        userService.DeleteUser(id);
    }
}


