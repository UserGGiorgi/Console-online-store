﻿namespace StoreDAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("customer_order_details")]
public class OrderDetail : BaseEntity
{
    public OrderDetail()
        : base()
    {
    }

    public OrderDetail(int id, int orderId, int productId, decimal price, int amount)
        : base(id)
    {
        this.OrderId = orderId;
        this.ProductId = productId;
        this.Price = price;
        this.ProductAmount = amount;
    }

    [ForeignKey("OrderId")]
    public int OrderId { get; set; }

    [ForeignKey("ProductId")]
    public int ProductId { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("product_amount")]
    public int ProductAmount { get; set; }

    public CustomerOrder Order { get; set; }

    public Product Product { get; set; }
}
