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
    public class ProductTitleRepository : AbstractRepository, IProductTitleRepository
    {
        private readonly DbSet<ProductTitle> dbSet;

        public ProductTitleRepository(StoreDbContext context)
            : base(context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.dbSet = context.Set<ProductTitle>();
        }

        public void Add(ProductTitle entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            this.dbSet.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(ProductTitle entity)
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

        public IEnumerable<ProductTitle> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<ProductTitle> GetAll(int pageNumber, int rowCount)
        {
            return this.dbSet
                       .Skip((pageNumber - 1) * rowCount)
                       .Take(rowCount)
                       .ToList();
        }

        public ProductTitle GetById(int id)
        {
           return this.dbSet.Find(id);
        }

        public void Update(ProductTitle entity)
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
