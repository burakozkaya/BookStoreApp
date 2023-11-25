using BookStoreApp.BLL.ResponsePattern;
using BookStoreApp.Dto.IDto;
using BookStoreApp.Entity.Abstract;

namespace BookStoreApp.BLL.Abstract;

// ReSharper disable once UnusedTypeParameter
public interface IGenericService<TListDto, TCreateDto, TUpdateDto, T>
    where T : class, IBaseEntity
    where TListDto : class, IEnumarableDto
    where TCreateDto : class, ICreateDto
    where TUpdateDto : class, IUpdateDto
{
    Task<Response<TCreateDto>> GetByIdAsync(int id);
    Task<Response> AddAsync(TCreateDto dto);
    Task<Response> UpdateAsync(TUpdateDto dto);
    Task<Response> RemoveAsync(int id);
    Task<Response<List<TListDto>>> GetAllIncludingAllAsync();
}