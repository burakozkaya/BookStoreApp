using AutoMapper;
using BookStoreApp.BLL.Abstract;
using BookStoreApp.BLL.ResponsePattern;
using BookStoreApp.DAL.UnitOfWork;
using BookStoreApp.Dto.Dto.AuthorDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Concrete;

public class AuthorManager : GenericManager<AuthorEnumerableDto, AuthorInsertDto, AuthorUpdateDto, Author>, IAuthorService
{
    public AuthorManager(IUow uow, IMapper mapper) : base(uow, mapper)
    {
    }

    public override async Task<Response<List<AuthorEnumerableDto>>> GetAllIncludingAllAsync()
    {
        try
        {
            var tempAuthorList = await _uow.AuthorRepository.GetAllIncludingAllAsync();
            var tempAuthorDto = _mapper.Map<List<AuthorEnumerableDto>>(tempAuthorList);
            return Response<List<AuthorEnumerableDto>>.Success(tempAuthorDto, "Mission Success");
        }
        catch (Exception e)
        {
            return Response<List<AuthorEnumerableDto>>.Fail("Mission Failed");
        }
    }
}