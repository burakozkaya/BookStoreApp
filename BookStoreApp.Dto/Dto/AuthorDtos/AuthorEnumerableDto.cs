using BookStoreApp.Dto.IDto;

namespace BookStoreApp.Dto.Dto.AuthorDto;

public class AuthorEnumerableDto : IEnumarableDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> BookTitles { get; set; }
}