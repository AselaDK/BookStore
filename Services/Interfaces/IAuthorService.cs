using BookStore.Models;

namespace BookStore.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAuthors();
        Task<AuthorDto> GetAuthor(int id);
        Task<AuthorDto> CreateAuthor(CreateAuthorDto dto);
        Task UpdateAuthor(int id, CreateAuthorDto dto);
        Task DeleteAuthor(int id);
    }
}
