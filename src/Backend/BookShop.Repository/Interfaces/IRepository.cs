using BookShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int identity);

        TEntity GetFirstOrDefault();

        TEntity Add(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}
