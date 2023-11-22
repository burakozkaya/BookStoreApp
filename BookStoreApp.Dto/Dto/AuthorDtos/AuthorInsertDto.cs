using BookStoreApp.Dto.IDto;

namespace BookStoreApp.Dto.Dto.AuthorDto;

public class AuthorInsertDto : ICreateDto
{
    public string Name { get; set; }
}