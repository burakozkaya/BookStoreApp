using BookStoreApp.Dto.Dto.BookDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Abstract;
public interface IBookService : IGenericService<BookEnumerableDto, BookInsertDto, BookUpdateDto, Book>
{

}