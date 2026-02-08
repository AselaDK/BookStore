
using BookStore.Models;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetBooks();
        Task<BookDto> GetBook(int id);
        Task<BookDto> CreateBook(CreateBookDto dto);
        Task UpdateBook(int id, CreateBookDto dto);
        Task DeleteBook(int id);
    }
}
