﻿namespace StoreBLL.Services;
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

public class CustomerOrderService : ICrud
{
    private readonly CustomerOrderRepository repository;

    public CustomerOrderService(StoreDbContext context)
    {
        this.repository = new CustomerOrderRepository(context);
    }

    public void Add(AbstractModel model)
    {
        var x = (CustomerOrderModel)model;
        this.repository.Add(new CustomerOrder(x.Id, x.OperationTime, x.UserId, x.OrderStateId));
    }

    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(x => new CustomerOrderModel(x.Id, x.OperationTime, x.UserId, x.OrderStateId));
    }

    public AbstractModel GetById(int id)
    {
        var res = this.repository.GetById(id);
        return new CustomerOrderModel(res.Id, res.OperationTime, res.UserId, res.OrderStateId);
    }

    public void Update(AbstractModel model)
    {
        var x = (CustomerOrderModel)model;
        this.repository.Update(new CustomerOrder(x.Id, x.OperationTime, x.UserId, x.OrderStateId));
    }
}