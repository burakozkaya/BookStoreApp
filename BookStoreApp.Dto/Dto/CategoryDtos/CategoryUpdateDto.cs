using BookStoreApp.Dto.IDto;

namespace BookStoreApp.Dto.Dto.CategoryDto;

public class CategoryUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}