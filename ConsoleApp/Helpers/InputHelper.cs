namespace ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBLL.Models;

internal static class InputHelper
{
    public static CategoryModel ReadCategoryiModel()
    {
        Console.WriteLine("Input category Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input category Name");
        var name = Console.ReadLine();
        ArgumentNullException.ThrowIfNull(name);
        return new CategoryModel(id, name);
    }

    public static ManufacturerModel ReadManufacturerModel()
    {
        Console.WriteLine("Input manufacturer Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input manufacturer Name");
        var name = Console.ReadLine();
        ArgumentNullException.ThrowIfNull(name);
        return new ManufacturerModel(id, name);
    }

    public static ProductTitleModel ReadProductTitleModel()
    {
        Console.WriteLine("Input State Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input State Name");
        var name = Console.ReadLine();
        Console.WriteLine("Input State CategoryId");
        var categoryId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        ArgumentNullException.ThrowIfNull(name);
        return new ProductTitleModel(id, name, categoryId);
    }

    public static OrderStateModel ReadOrderStateModel()
    {
        Console.WriteLine("Input State Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input State Name");
        var name = Console.ReadLine();
        ArgumentNullException.ThrowIfNull(name);
        return new OrderStateModel(id, name);
    }

    public static OrderDetailModel ReadOrderDetailModel()
    {
        Console.WriteLine("Input State Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input State Id");
        var orderId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input State ProductId");
        var productId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input State price");
        var price = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input State amount");
        var amount = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        return new OrderDetailModel(id, orderId, productId, price, amount);
    }

    public static UserRoleModel ReadUserRoleModel()
    {
        Console.WriteLine("Input User Role Id");
        var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
        Console.WriteLine("Input User Role Name");
        var name = Console.ReadLine();
        ArgumentNullException.ThrowIfNull(name);
        return new UserRoleModel(id, name);
    }
}
