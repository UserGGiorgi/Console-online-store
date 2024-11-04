namespace StoreBLL.Models;
using StoreDAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CategoryModel : AbstractModel
{
    public CategoryModel(int id, string categoryName)
        : base(id)
    {
        this.Id = id;
        this.CategoryName = categoryName;
    }

    public string CategoryName { get; set; }

    public override string ToString()
    {
        return $"Id:{this.Id} ,{this.CategoryName}";
    }
}
