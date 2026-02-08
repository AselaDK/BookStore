using BookStore.Data;
using BookStore.Models;
using BookStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class BookService: IBookService
    {
        private readonly BookStoreContext _context;

        public BookService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<BookDto>> GetBooks()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Price = b.Price,
                    AuthorId = b.AuthorId,
                    AuthorName = b.Author.Name
                })
                .ToListAsync();
        }

        public async Task<BookDto> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                AuthorId = book.AuthorId,
                AuthorName = book.Author.Name
            };
        }

        public async Task<BookDto> CreateBook(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Price = dto.Price,
                AuthorId = dto.AuthorId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            await _context.Entry(book)
                .Reference(b => b.Author)
                .LoadAsync();

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                AuthorId = book.AuthorId,
                AuthorName = book.Author.Name
            };
        }

        public async Task UpdateBook(int id, CreateBookDto dto)
        {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                book.Title = dto.Title;
                book.Price = dto.Price;
                book.AuthorId = dto.AuthorId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
