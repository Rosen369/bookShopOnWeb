using BookShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookShop.Repository
{
    public class BookShopContext : DbContext
    {
        public BookShopContext()
        {

        }

        public DbSet<Book> Books
        {
            get { return this.Set<Book>(); }
        }
    }
}
