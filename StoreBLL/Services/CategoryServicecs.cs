namespace StoreBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBLL.Interfaces;
using StoreBLL.Models;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;
using StoreDAL.Repository;

public class CategoryService : ICrud
{
    private readonly ICategoryRepository repository;

    public CategoryService(StoreDbContext context)
    {
        this.repository = new CategoryRepository(context);
    }

    public void Add(AbstractModel model)
    {
        var res = (CategoryModel)model;
        this.repository.Add(new Category(res.Id, res.CategoryName));
    }

    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(x => new CategoryModel(x.Id, x.Name));
    }

    public AbstractModel GetById(int id)
    {
        var res = this.repository.GetById(id);
        return new CategoryModel(res.Id, res.Name);
    }

    public void Update(AbstractModel model)
    {
        var res = (CategoryModel)model;
        this.repository.Update(new Category(res.Id, res.CategoryName));
    }
}
