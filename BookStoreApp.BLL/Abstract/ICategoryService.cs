using BookStoreApp.Dto.Dto.CategoryDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Abstract;

public interface ICategoryService : IGenericService<CategoryEnumerableDto, CategoryInsertDto, CategoryUpdateDto, Category>
{

}