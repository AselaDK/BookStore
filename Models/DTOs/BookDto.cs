namespace BookStore.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }

    public class CreateBookDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
    }
}
