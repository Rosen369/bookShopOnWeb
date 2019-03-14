using BookShop.Domain.Entities;
using BookShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Repository
{
    public class BookRepository : EfRepository<Book>, IBookRepository
    {
        public BookRepository(BookShopContext dbContext) : base(dbContext)
        {
        }
    }
}
