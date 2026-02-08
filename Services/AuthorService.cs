using BookStore.Data;
using BookStore.Models;
using BookStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class AuthorService: IAuthorService
    {
        private readonly BookStoreContext _context;

        public AuthorService(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<AuthorDto>> GetAuthors()
        {
            return await _context.Authors
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync();
        }

        public async Task<AuthorDto> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null) return null;

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public async Task<AuthorDto> CreateAuthor(CreateAuthorDto dto)
        {
            var author = new Author { Name = dto.Name };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public async Task UpdateAuthor(int id, CreateAuthorDto dto)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author != null)
            {
                author.Name = dto.Name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}
