﻿namespace StoreDAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("product_titles")]
public class ProductTitle : BaseEntity
{
    public ProductTitle()
        : base()
    {
    }

    public ProductTitle(int id, string title, int categoryId)
        : base(id)
    {
        this.Title = title;
        this.CategoryId = categoryId;
    }

    [Column("product_title")]
    public string Title { get; set; }

    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public virtual IList<Product> Products { get; set; }
}
