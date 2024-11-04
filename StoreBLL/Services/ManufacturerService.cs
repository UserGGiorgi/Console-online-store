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

public class ManufacturerService : ICrud
{
    private readonly IManufacturerRepository repository;

    public ManufacturerService(StoreDbContext context)
    {
        this.repository = new ManufacturerRepository(context);
    }

    public void Add(AbstractModel model)
    {
        var res = (ManufacturerModel)model;
        this.repository.Add(new Manufacturer(res.Id, res.Name));
    }

    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(x => new ManufacturerModel(x.Id, x.Name));
    }

    public AbstractModel GetById(int id)
    {
        var res = this.repository.GetById(id);
        return new ManufacturerModel(res.Id, res.Name);
    }

    public void Update(AbstractModel model)
    {
        var res = (ManufacturerModel)model;
        this.repository.Update(new Manufacturer(res.Id, res.Name));
    }
}