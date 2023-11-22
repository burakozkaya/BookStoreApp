using BookStoreApp.Dto.IDto;

namespace BookStoreApp.Dto.Dto.BookDto;

public class BookUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
}