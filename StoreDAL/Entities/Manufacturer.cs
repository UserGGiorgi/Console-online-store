﻿namespace StoreDAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoreDAL.Entities;

[Table("manufacturers")]
public class Manufacturer : BaseEntity
{
    public Manufacturer()
        : base()
    {
    }

    public Manufacturer(int id, string name)
        : base(id)
    {
        this.Name = name;
    }

    [Column("manufacturer_name")]
    public string Name { get; set; }

    public virtual IList<Product> Products { get; set; }
}
