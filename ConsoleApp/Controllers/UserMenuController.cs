using ConsoleMenu;
using ConsoleMenu.Builder;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StoreDAL.Data;
using StoreDAL.Data.InitDataFactory;

namespace ConsoleApp1;

public enum UserRoles
{
    Guest,
    Administrator,
    RegistredCustomer,
}

public static class UserMenuController
{
    private static readonly Dictionary<UserRoles, Menu> RolesToMenu;
    private static int userId;
    private static UserRoles userRole;
    private static StoreDbContext context;

    public static int UserId
    {
        get { return userId; }
    }

    static UserMenuController()
    {
        userId = 0;
        userRole = UserRoles.Guest;
        RolesToMenu = new Dictionary<UserRoles, Menu>();
        var factory = new StoreDbFactory(new TestDataFactory());
        context = factory.CreateContext();
        RolesToMenu.Add(UserRoles.Guest, new GuestMainMenu().Create(context));
        RolesToMenu.Add(UserRoles.RegistredCustomer, new UserMainMenu().Create(context));
        RolesToMenu.Add(UserRoles.Administrator, new AdminMainMenu().Create(context));
    }

    public static StoreDbContext Context
    {
        get { return context; }
    }

    public static void Login()
    {
        Console.WriteLine("Login: ");
        var login = Console.ReadLine();
        Console.WriteLine("Password: ");
        var password = Console.ReadLine();
        if (login == "admin")
        {
            userId = 1;
            userRole = UserRoles.Administrator;
        }
        else if (login == "user")
        {
            userId = 1;
            userRole = UserRoles.RegistredCustomer;
        }
        else
        {
            ArgumentNullException.ThrowIfNull(login);
            ArgumentNullException.ThrowIfNull(password);
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = System.Security.Cryptography.SHA256.HashData(bytes);
            var encryptedPassword = Convert.ToBase64String(hash);
            var user = context.Users.FirstOrDefault(u => u.Login == login);
            ArgumentNullException.ThrowIfNull(user);
            if (encryptedPassword == user.Password)
            {
                userId = 1;
                userRole = UserRoles.RegistredCustomer;
            }
        }
    }

    public static void Logout()
    {
        userId = 0;
        userRole = UserRoles.Guest;
    }

    public static void Start()
    {
        ConsoleKey resKey;
        bool updateItems = true;
        do
        {
                resKey = RolesToMenu[userRole].RunOnce(ref updateItems);
        }
        while (resKey != ConsoleKey.Escape);
    }
}