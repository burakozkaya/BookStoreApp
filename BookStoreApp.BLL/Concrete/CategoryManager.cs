using AutoMapper;
using BookStoreApp.BLL.Abstract;
using BookStoreApp.DAL.UnitOfWork;
using BookStoreApp.Dto.Dto.CategoryDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Concrete;

public class CategoryManager : GenericManager<CategoryEnumerableDto, CategoryInsertDto, CategoryUpdateDto, Category>, ICategoryService
{
    public CategoryManager(IUow uow, IMapper mapper) : base(uow, mapper)
    {
    }
}