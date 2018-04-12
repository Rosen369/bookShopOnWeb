using BookShop.Contract.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Contract.Repository
{
    public interface IRepository<TEntity, IdentityType> where TEntity : IEntity<IdentityType>
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(IdentityType identity);

        TEntity GetFirstOrDefault();

        void Add(TEntity entity);

        void Delete(IdentityType identity);

        void Update(TEntity entity);
    }
}
