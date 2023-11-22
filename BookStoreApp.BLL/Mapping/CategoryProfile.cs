using AutoMapper;
using BookStoreApp.Dto.Dto.CategoryDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryEnumerableDto>()
            .ForMember(dest => dest.BookTitles, opt => opt.MapFrom(src => src.Books.Select(x => x.Title)))
            .ReverseMap();

        CreateMap<Category, CategoryInsertDto>()
            .ReverseMap();

        CreateMap<Category, CategoryUpdateDto>()
            .ReverseMap()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
    }
}