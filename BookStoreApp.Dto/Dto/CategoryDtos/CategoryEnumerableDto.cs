using BookStoreApp.Dto.IDto;

namespace BookStoreApp.Dto.Dto.CategoryDto;

public class CategoryEnumerableDto : IEnumarableDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> BookTitles { get; set; }
}