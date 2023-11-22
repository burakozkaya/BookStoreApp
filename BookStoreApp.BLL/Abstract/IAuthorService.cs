using BookStoreApp.Dto.Dto.AuthorDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Abstract;

public interface IAuthorService : IGenericService<AuthorEnumerableDto, AuthorInsertDto, AuthorUpdateDto, Author>
{

}