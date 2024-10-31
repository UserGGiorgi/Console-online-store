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
    public class ProductRepository : AbstractRepository, IProductRepository
    {
        private readonly DbSet<Product> dbSet;

        public ProductRepository(StoreDbContext context)
            : base(context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.dbSet = context.Set<Product>();
        }

        public void Add(Product entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(Product entity)
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

        public IEnumerable<Product> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<Product> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet
                       .Skip((pageNumber - 1) * rowCount)
                       .Take(rowCount)
                       .ToList();
        }

        public Product GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(Product entity)
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