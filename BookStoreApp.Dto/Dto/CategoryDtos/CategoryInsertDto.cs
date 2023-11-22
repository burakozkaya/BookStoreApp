using BookStoreApp.Dto.IDto;

namespace BookStoreApp.Dto.Dto.CategoryDto;

public class CategoryInsertDto : ICreateDto
{
    public string Name { get; set; }
}