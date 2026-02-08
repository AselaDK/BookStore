using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var authors = new[]
            {
                new Author { Id = 1, Name = "J.K. Rowling" },
                new Author { Id = 2, Name = "George Orwell" }
            };

            var books = new[]
            {
                new BookDto { Id = 1, Title = "Harry Potter", Price = 19.99m, AuthorId = 1 },
                new BookDto { Id = 2, Title = "1984", Price = 9.99m, AuthorId = 2 },
                new BookDto { Id = 3, Title = "Animal Farm", Price = 7.99m, AuthorId = 2 }
            };

            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}
