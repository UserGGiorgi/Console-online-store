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
    public class OrderDetailRepository : AbstractRepository, IOrderDetailRepository
    {
        private readonly DbSet<OrderDetail> dbSet;

        public OrderDetailRepository(StoreDbContext context)
            : base(context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.dbSet = context.Set<OrderDetail>();
        }

        public void Add(OrderDetail entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(OrderDetail entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = this.dbSet.Find(id);
            if (entity != null)
            {
                this.dbSet.Remove(entity);
                this.context.SaveChanges();
            }
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<OrderDetail> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet
                       .Skip((pageNumber - 1) * rowCount)
                       .Take(rowCount)
                       .ToList();
        }

        public OrderDetail GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(OrderDetail entity)
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
