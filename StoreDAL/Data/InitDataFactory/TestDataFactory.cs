namespace StoreDAL.Data.InitDataFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDAL.Entities;

public class TestDataFactory : AbstractDataFactory
{
    public override Category[] GetCategoryData()
    {
        return new[]
        {
            new Category(1, "fruits"),
            new Category(2, "water"),
            new Category(3, "vegetables"),
            new Category(4, "seafood"),
            new Category(5, "meet"),
            new Category(6, "grocery"),
            new Category(7, "milk food"),
            new Category(8, "smartphones"),
            new Category(9, "laptop"),
            new Category(10, "photocameras"),
            new Category(11, "kitchen accesories"),
            new Category(12, "spices"),
            new Category(13, "Juice"),
            new Category(14, "alcohol drinks"),
        };
    }

    public override CustomerOrder[] GetCustomerOrderData()
    {
        return new CustomerOrder[]
    {
        new CustomerOrder
        {
            Id = 1,
            UserId = 1,
            OperationTime = "01-01-2024",
            OrderStateId = 1,
        },
        new CustomerOrder
        {
            Id = 2,
            UserId = 1,
            OperationTime = "01-01-2024",
            OrderStateId = 1,
        },
    };
    }

    public override Manufacturer[] GetManufacturerData()
    {
        return new Manufacturer[]
    {
        new Manufacturer
        {
            Id = 1,
            Name = "ABC Electronics",
        },
        new Manufacturer
        {
            Id = 2,
            Name = "XYZ Appliances",
        },
    };
    }

    public override OrderDetail[] GetOrderDetailData()
    {
        return new OrderDetail[]
    {
        new OrderDetail
        {
            Id = 1,
            OrderId = 1,
            ProductId = 2,
            Price = 19.99m,
            ProductAmount = 2,
        },
        new OrderDetail
        {
            Id = 2,
            OrderId = 2,
            ProductId = 1,
            Price = 29.99m,
            ProductAmount = 1,
        },
    };
    }

    public override OrderState[] GetOrderStateData()
    {
        return new[]
        {
            new OrderState(1, "New Order"),
            new OrderState(2, "Cancelled by user"),
            new OrderState(3, "Cancelled by administrator"),
            new OrderState(4, "Confirmed"),
            new OrderState(5, "Moved to delivery company"),
            new OrderState(6, "In delivery"),
            new OrderState(7, "Delivered to client"),
            new OrderState(8, "Delivery confirmed by client"),
        };
    }

    public override Product[] GetProductData()
    {
        return new Product[]
    {
        new Product
        {
            Id = 1,
            TitleId = 1,
            ManufacturerId = 1,
            UnitPrice = 9.99m,
            Description = "Sample product A",
        },
        new Product
        {
            Id = 2,
            TitleId = 1,
            ManufacturerId = 1,
            UnitPrice = 14.99m,
            Description = "Sample product B",
        },
    };
    }

    public override ProductTitle[] GetProductTitleData()
    {
        return new ProductTitle[]
    {
        new ProductTitle
        {
            Id = 1,
            Title = "Product A Title",
            CategoryId = 1,
        },
        new ProductTitle
        {
            Id = 2,
            Title = "Product B Title",
            CategoryId = 1,
        },
    };
    }

    public override User[] GetUserData()
    {
        return new User[]
    {
        new User
        {
            Id = 1,
            Name = "Alice",
            LastName = "Smith",
            Login = "alice.smith",
            Password = "password123",
            RoleId = 1,
        },
        new User
        {
            Id = 2,
            Name = "Bob",
            LastName = "Johnson",
            Login = "bob.johnson",
            Password = "securepassword",
            RoleId = 2,
        },
    };
    }

    public override UserRole[] GetUserRoleData()
    {
        return new[]
        {
            new UserRole(1, "Admin"),
            new UserRole(2, "Registered"),
            new UserRole(3, "Guest"),
        };
    }
}
