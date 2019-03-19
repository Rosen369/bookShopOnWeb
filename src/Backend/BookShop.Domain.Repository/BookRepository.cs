using BookShop.Domain.Abstraction.Repository;
using BookShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Domain.Repository
{
    public class BookRepository : EfRepository<Book>, IBookRepository
    {
        public BookRepository(BookShopContext dbContext) : base(dbContext)
        {
        }
    }
}
