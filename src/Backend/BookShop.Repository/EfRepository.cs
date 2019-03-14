using BookShop.Domain;
using BookShop.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Repository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly BookShopContext _dbContext;

        public EfRepository(BookShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public virtual TEntity GetById(int identity)
        {
            return _dbContext.Set<TEntity>().Find(identity);
        }

        public TEntity GetFirstOrDefault()
        {
            return _dbContext.Set<TEntity>().FirstOrDefault();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
