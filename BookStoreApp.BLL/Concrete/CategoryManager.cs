using AutoMapper;
using BookStoreApp.BLL.Abstract;
using BookStoreApp.BLL.ResponsePattern;
using BookStoreApp.DAL.UnitOfWork;
using BookStoreApp.Dto.Dto.CategoryDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Concrete;

public class CategoryManager : GenericManager<CategoryEnumerableDto, CategoryInsertDto, CategoryUpdateDto, Category>, ICategoryService
{
    public CategoryManager(IUow uow, IMapper mapper) : base(uow, mapper)
    {
    }

    public override async Task<Response<List<CategoryEnumerableDto>>> GetAllIncludingAllAsync()
    {
        try
        {
            var tempEntityList = await _uow.CategoryRepository.GetAllIncludingAllAsync();
            var tempDto = _mapper.Map<List<CategoryEnumerableDto>>(tempEntityList);
            return Response<List<CategoryEnumerableDto>>.Success(tempDto, "Mission Success");
        }
        catch (Exception e)
        {
            return Response<List<CategoryEnumerableDto>>.Fail("Mission Failed");
        }
    }
}