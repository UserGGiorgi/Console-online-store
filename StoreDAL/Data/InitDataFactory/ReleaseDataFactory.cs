namespace StoreDAL.Data.InitDataFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDAL.Entities;

public class ReleaseDataFactory : AbstractDataFactory
{
    public override Category[] GetCategoryData()
    {
        return new[]
    {
        new Category(1, "Electronics"),
        new Category(2, "Home Appliances"),
        new Category(3, "Furniture"),
        new Category(4, "Books"),
        new Category(5, "Toys"),
    };
    }

    public override CustomerOrder[] GetCustomerOrderData()
    {
        return new[]
    {
        new CustomerOrder(1, "2023-10-01 10:30:00", 1, 4),
        new CustomerOrder(2, "2023-10-02 14:45:00", 2, 1),
        new CustomerOrder(3, "2023-10-03 09:15:00", 3, 6),
        new CustomerOrder(4, "2023-10-04 11:20:00", 4, 3),
        new CustomerOrder(5, "2023-10-05 16:05:00", 5, 5),
    };
    }

    public override Manufacturer[] GetManufacturerData()
    {
        return new[]
    {
        new Manufacturer(1, "TechCorp"),
        new Manufacturer(2, "SoundWave Inc."),
        new Manufacturer(3, "Vision Electronics"),
        new Manufacturer(4, "SmartHome Solutions"),
        new Manufacturer(5, "Gadget World"),
    };
    }

    public override OrderDetail[] GetOrderDetailData()
    {
        return new[]
    {
        new OrderDetail(1, 1, 1, 1499.99m, 1),
        new OrderDetail(2, 1, 2, 299.99m, 2),
        new OrderDetail(3, 2, 3, 19.99m, 3),
        new OrderDetail(4, 2, 4, 799.99m, 1),
        new OrderDetail(5, 3, 5, 129.99m, 4),
        new OrderDetail(6, 3, 6, 249.99m, 1),
    };
    }

    public override OrderState[] GetOrderStateData()
    {
        return new[]
        {
            new OrderState(1, "New Order"),
            new OrderState(2, "Canceled by user"),
            new OrderState(3, "Canceled by administrator"),
            new OrderState(4, "Confirmed"),
            new OrderState(5, "Moved to delivery company"),
            new OrderState(6, "In delivery"),
            new OrderState(7, "Delivered to client"),
            new OrderState(8, "Delivery aproved by client"),
        };
    }

    public override Product[] GetProductData()
    {
        return new[]
    {
        new Product(1, 1, 1, "High-performance gaming laptop with RGB keyboard.", 1499.99m),
        new Product(2, 2, 2, "Noise-canceling wireless headphones with superior sound quality.", 299.99m),
        new Product(3, 3, 1, "Durable smartphone case for maximum protection.", 19.99m),
        new Product(4, 4, 3, "Stunning 4K Ultra HD TV with vibrant colors.", 799.99m),
        new Product(5, 5, 2, "Compact Bluetooth speaker with deep bass.", 129.99m),
        new Product(6, 6, 1, "Smartwatch with health tracking features and customizable watch faces.", 249.99m),
    };
    }

    public override ProductTitle[] GetProductTitleData()
    {
        return new[]
    {
        new ProductTitle(1, "Gaming Laptop", 1),
        new ProductTitle(2, "Wireless Headphones", 2),
        new ProductTitle(3, "Smartphone Case", 1),
        new ProductTitle(4, "4K Ultra HD TV", 3),
        new ProductTitle(5, "Bluetooth Speaker", 2),
        new ProductTitle(6, "Smartwatch", 1),
    };
    }

    public override User[] GetUserData()
    {
        return new[]
    {
        new User(1, "Alice", "Johnson", "alice.johnson", "password123", 1),
        new User(2, "Bob", "Smith", "bob.smith", "securepass456", 2),
        new User(3, "Charlie", "Brown", "charlie.brown", "mypassword789", 1),
        new User(4, "Diana", "Prince", "diana.prince", "wonderwoman2024", 3),
        new User(5, "Evan", "Lee", "evan.lee", "evanpassword101", 2),
    };
    }

    public override UserRole[] GetUserRoleData()
    {
        return new[]
        {
            new UserRole(1, "Admin"),
            new UserRole(2, "Registred"),
            new UserRole(3, "Guest"),
        };
    }
}