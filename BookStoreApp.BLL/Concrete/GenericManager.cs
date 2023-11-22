using BookStoreApp.BLL.Abstract;
using BookStoreApp.BLL.ResponsePattern;
using BookStoreApp.DAL.UnitOfWork;
using BookStoreApp.Entity.Abstract;

namespace BookStoreApp.BLL.Concrete;

public class GenericManager<T> : IGenericService<T> where T : class, IBaseEntity
{
    private readonly IUOW _uow;

    public GenericManager(IUOW uow)
    {
        _uow = uow;
    }
    public async Task<Response<List<T>>> GetAllAsync()
    {
        try
        {
            var tempList = await _uow.GetGenericRepository<T>().GetAllAsync();
            return Response<List<T>>.Success(tempList, "Mission Success");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Response<List<T>>.Fail(e.Message);
        }
    }


    public async Task<Response<T?>> GetByIdAsync(int id)
    {

        try
        {
            var tempData = await _uow.GetGenericRepository<T>().GetByIdAsync(id);
            return Response<T?>.Success(tempData, "Mission Success");
        }
        catch (Exception e)
        {
            return Response<T?>.Fail(e.Message);
        }
    }

    public async Task<Response> AddAsync(T entity)
    {
        try
        {
            await _uow.GetGenericRepository<T>().AddAsync(entity);
            await _uow.SaveAsync();

            return Response.Success("Mission Success");
        }
        catch (Exception e)
        {
            return Response.Fail(e.Message);
        }
    }

    public async Task<Response> UpdateAsync(T entity)
    {
        try
        {
            await _uow.GetGenericRepository<T>().UpdateAsync(entity);
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
}