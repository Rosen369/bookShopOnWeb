using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BookShop.Repository
{
    public class BookShopContext : DbContext
    {
        public BookShopContext(DbContextOptions<BookShopContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(ConfigureBook);
        }

        private void ConfigureBook(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("book_hilo")
                .IsRequired();

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Price)
                .IsRequired(true);

            builder.Property(ci => ci.Author)
                .IsRequired(true);

            builder.Property(ci => ci.Description)
                .IsRequired(false);
        }
    }
}
