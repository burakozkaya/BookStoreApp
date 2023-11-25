using AutoMapper;
using BookStoreApp.BLL.Abstract;
using BookStoreApp.DAL.UnitOfWork;
using BookStoreApp.Dto.Dto.AuthorDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Concrete;

public class AuthorManager : GenericManager<AuthorEnumerableDto, AuthorInsertDto, AuthorUpdateDto, Author>, IAuthorService
{
    public AuthorManager(IUow uow, IMapper mapper) : base(uow, mapper)
    {
    }
}