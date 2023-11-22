using BookStoreApp.Dto.IDto;

namespace BookStoreApp.Dto.Dto.BookDto;

public class BookEnumerableDto : IEnumarableDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryName { get; set; }
    public string AuthorName { get; set; }
}