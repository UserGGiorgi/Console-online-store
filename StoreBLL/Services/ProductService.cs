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

public class ProductService : ICrud
{
    private readonly IProductRepository repository;

    public ProductService(StoreDbContext context)
    {
        this.repository = new ProductRepository(context);
    }

    public void Add(AbstractModel model)
    {
        var x = (ProductModel)model;
        this.repository.Add(new Product(x.Id, x.TitleId, x.ManufacturerId, x.Description, x.Price));
    }

    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(x => new ProductModel(x.Id, x.TitleId, x.ManufacturerId, x.Description, x.UnitPrice));
    }

    public AbstractModel GetById(int id)
    {
        var x = this.repository.GetById(id);
        return new ProductModel(x.Id, x.TitleId, x.ManufacturerId, x.Description, x.UnitPrice);
    }

    public void Update(AbstractModel model)
    {
        var x = (ProductModel)model;
        this.repository.Update(new Product(x.Id, x.TitleId, x.ManufacturerId, x.Description, x.Price));
    }
}
