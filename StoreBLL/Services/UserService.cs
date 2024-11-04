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

public class UserService : ICrud
{
    private readonly UserRepository repository;

    public UserService(StoreDbContext context)
    {
        this.repository = new UserRepository(context);
    }

    public void Add(AbstractModel model)
    {
        var x = (UserModel)model;
        this.repository.Add(new User(x.Id, x.Name, x.LastName, x.Login, x.Password, x.RoleId));
    }

    public void Delete(int modelId)
    {
        this.repository.DeleteById(modelId);
    }

    public IEnumerable<AbstractModel> GetAll()
    {
        return this.repository.GetAll().Select(x => new UserModel(x.Id, x.Name, x.LastName, x.Login, x.Password, x.RoleId));
    }

    public AbstractModel GetById(int id)
    {
        var x = this.repository.GetById(id);
        return new UserModel(x.Id, x.Name, x.LastName, x.Login, x.Password, x.RoleId);
    }

    public void Update(AbstractModel model)
    {
        var x = (UserModel)model;
        this.repository.Update(new User(x.Id, x.Name, x.LastName, x.Login, x.Password, x.RoleId));
    }
}
