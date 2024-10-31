using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreDAL.Data;
using StoreDAL.Entities;
using StoreDAL.Interfaces;

namespace StoreDAL.Repository
{
    public class CustomerOrderRepository : AbstractRepository, ICustomerOrderRepository
    {
        private readonly DbSet<CustomerOrder> dbSet;

        public CustomerOrderRepository(StoreDbContext context)
            : base(context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.dbSet = context.Set<CustomerOrder>();
        }

        public void Add(CustomerOrder entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(CustomerOrder entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = this.dbSet.Find(id);
            ArgumentNullException.ThrowIfNull(entity);
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public IEnumerable<CustomerOrder> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<CustomerOrder> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet
                       .Skip((pageNumber - 1) * rowCount)
                       .Take(rowCount)
                       .ToList();
        }

        public CustomerOrder GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(CustomerOrder entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            var existingUser = this.GetById(entity.Id);
            if (existingUser != null)
            {
                this.dbSet.Update(existingUser);
            }
        }
    }
}
