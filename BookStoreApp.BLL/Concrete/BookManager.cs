using AutoMapper;
using BookStoreApp.BLL.Abstract;
using BookStoreApp.DAL.UnitOfWork;
using BookStoreApp.Dto.Dto.BookDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Concrete;

public class BookManager : GenericManager<BookEnumerableDto, BookInsertDto, BookUpdateDto, Book>, IBookService
{
    public BookManager(IUOW uow, IMapper mapper) : base(uow, mapper)
    {
    }
}