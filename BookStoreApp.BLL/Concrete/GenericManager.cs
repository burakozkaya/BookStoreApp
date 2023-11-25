using AutoMapper;
using BookStoreApp.BLL.Abstract;
using BookStoreApp.BLL.ResponsePattern;
using BookStoreApp.DAL.UnitOfWork;
using BookStoreApp.Dto.IDto;
using BookStoreApp.Entity.Abstract;
namespace BookStoreApp.BLL.Concrete;
public class GenericManager<TListDto, TCreateDto, TUpdateDto, T> : IGenericService<TListDto, TCreateDto, TUpdateDto, T>
    where T : class, IBaseEntity
    where TListDto : class, IEnumarableDto
    where TCreateDto : class, ICreateDto
    where TUpdateDto : class, IUpdateDto
{
    protected readonly IUow _uow;
    protected readonly IMapper _mapper;

    public GenericManager(IUow uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    public async Task<Response<TCreateDto>> GetByIdAsync(int id)
    {

        try
        {
            var tempData = await _uow.GetGenericRepository<T>().GetByIdAsync(id);
            var TCreateorUpdateDto = _mapper.Map<TCreateDto>(tempData);
            return Response<TCreateDto>.Success(TCreateorUpdateDto, "Mission Success");
        }
        catch (Exception e)
        {
            return Response<TCreateDto>.Fail(e.Message);
        }
    }

    public async Task<Response> AddAsync(TCreateDto entity)
    {
        try
        {

            var Tentity = _mapper.Map<T>(entity);
            await _uow.GetGenericRepository<T>().AddAsync(Tentity);
            await _uow.SaveAsync();

            return Response.Success("Mission Success");
        }
        catch (Exception e)
        {
            return Response.Fail(e.Message);
        }
    }
    public async Task<Response> UpdateAsync(TUpdateDto entity)
    {
        try
        {
            var Tentity = _mapper.Map<T>(entity);
            await _uow.GetGenericRepository<T>().UpdateAsync(Tentity);
            await _uow.SaveAsync();
            return Response.Success("Mission success");
        }
        catch (Exception e)
        {
            return Response.Fail(e.Message);
        }
    }

    public async Task<Response> RemoveAsync(int id)
    {
        try
        {
            await _uow.GetGenericRepository<T>().RemoveAsync(id);
            await _uow.SaveAsync();
            return Response.Success("Mission success");
        }
        catch (Exception e)
        {
            return Response.Fail(e.Message);
        }
    }

    public virtual async Task<Response<List<TListDto>>> GetAllIncludingAllAsync()
    {
        try
        {
            var tempData = await _uow.GetGenericRepository<T>().GetAllIncludingAllAsync();
            var listDto = _mapper.Map<List<TListDto>>(tempData);
            return Response<List<TListDto>>.Success(listDto, "Mission success");
        }
        catch (Exception e)
        {
            return Response<List<TListDto>>.Fail(e.Message);

        }
    }
}