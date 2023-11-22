using AutoMapper;
using BookStoreApp.Dto.Dto.BookDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Mapping;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookEnumerableDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ReverseMap();

        CreateMap<Book, BookInsertDto>().ReverseMap();

        CreateMap<Book, BookUpdateDto>()
            .ReverseMap();


    }
}