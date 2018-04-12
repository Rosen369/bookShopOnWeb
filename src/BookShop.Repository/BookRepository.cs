using BookShop.Contract.Repository;
using BookShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Repository
{
    public class BookRepository : IBookRepository, IRepository<Book, long>
    {
        public void Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long identity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book GetById(long identity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Book GetFirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
