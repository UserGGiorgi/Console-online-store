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

public class OrderDetailService : ICrud
{
    private readonly IOrderDetailRepository repository;

    public OrderDetailService(StoreDbContext context)
    {
        this.repository = new OrderDetailRepository(context);
    }

    public void Add(AbstractModel model)
    {
        var res = (OrderDetailModel)model;
        this.repository.Add(new OrderDetail(res.Id, res.OrderId, res.ProductId, res.Price, res.Amount));
    }

    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(x => new OrderDetailModel(x.Id, x.OrderId, x.ProductId, x.Price, x.ProductAmount));
    }

    public AbstractModel GetById(int id)
    {
        var res = this.repository.GetById(id);
        return new OrderDetailModel(res.Id, res.OrderId, res.ProductId, res.Price, res.ProductAmount);
    }

    public void Update(AbstractModel model)
    {
        var res = (OrderDetailModel)model;
        this.repository.Update(new OrderDetail(res.Id, res.OrderId, res.ProductId, res.Price, res.Amount));
    }
}