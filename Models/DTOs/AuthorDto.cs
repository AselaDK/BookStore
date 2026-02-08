namespace BookStore.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateAuthorDto
    {
        public string Name { get; set; }
    }
}
