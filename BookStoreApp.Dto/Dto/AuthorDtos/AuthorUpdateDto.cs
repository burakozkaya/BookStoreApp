using BookStoreApp.Dto.IDto;

namespace BookStoreApp.Dto.Dto.AuthorDto;

public class AuthorUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}