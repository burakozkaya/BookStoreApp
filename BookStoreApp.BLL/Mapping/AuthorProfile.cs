using AutoMapper;
using BookStoreApp.Dto.Dto.AuthorDto;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.BLL.Mapping;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorEnumerableDto>()
            .ForMember(dest => dest.BookTitles, opt => opt.MapFrom(src => src.Books.Select(x => x.Title)));

        CreateMap<Author, AuthorInsertDto>().ReverseMap();

        CreateMap<Author, AuthorUpdateDto>()
            .ReverseMap()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));


    }
}