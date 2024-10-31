namespace StoreDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data.InitDataFactory;
using StoreDAL.Entities;

public class StoreDbContext : DbContext
{
    private readonly AbstractDataFactory factory;

    public StoreDbContext(DbContextOptions options, AbstractDataFactory factory)
        : base(options)
    {
        this.factory = factory;
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<CustomerOrder> CustomerOrders { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<OrderState> OrderStates { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductTitle> ProductTitles { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        modelBuilder.Entity<Category>().HasData(this.factory.GetCategoryData());
        modelBuilder.Entity<Manufacturer>().HasData(this.factory.GetManufacturerData());
        modelBuilder.Entity<OrderState>().HasData(this.factory.GetOrderStateData());
        modelBuilder.Entity<UserRole>().HasData(this.factory.GetUserRoleData());
        modelBuilder.Entity<User>().HasData(this.factory.GetUserData());
        modelBuilder.Entity<ProductTitle>().HasData(this.factory.GetProductTitleData());
        modelBuilder.Entity<Product>().HasData(this.factory.GetProductData());
        modelBuilder.Entity<CustomerOrder>().HasData(this.factory.GetCustomerOrderData());
        modelBuilder.Entity<OrderDetail>().HasData(this.factory.GetOrderDetailData());

        modelBuilder.Entity<User>()
           .HasOne(u => u.Role)
           .WithMany(ur => ur.User)
           .HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<CustomerOrder>()
            .HasOne(co => co.User)
            .WithMany(c => c.Order)
            .HasForeignKey(co => co.UserId);

        modelBuilder.Entity<CustomerOrder>()
            .HasOne(co => co.State)
            .WithMany(os => os.Order)
            .HasForeignKey(co => co.OrderStateId);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(cod => cod.Order)
            .WithMany(co => co.Details)
            .HasForeignKey(cod => cod.OrderId);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(cod => cod.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Manufacturer)
            .WithMany(pt => pt.Products)
            .HasForeignKey(p => p.ManufacturerId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Title)
            .WithMany(pt => pt.Products)
            .HasForeignKey(p => p.TitleId);

        modelBuilder.Entity<ProductTitle>()
            .HasOne(pt => pt.Category)
            .WithMany(c => c.Titles)
            .HasForeignKey(pt => pt.CategoryId);
    }
}
