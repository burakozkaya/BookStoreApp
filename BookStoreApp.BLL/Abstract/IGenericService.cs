using BookStoreApp.BLL.ResponsePattern;
using BookStoreApp.Entity.Abstract;

namespace BookStoreApp.BLL.Abstract;

public interface IGenericService<T> where T : class, IBaseEntity
{
    Task<Response<List<T>>> GetAllAsync();
    Task<Response<T?>> GetByIdAsync(int id);
    Task<Response> AddAsync(T entity);
    Task<Response> UpdateAsync(T entity);
    Task<Response> RemoveAsync(int id);
}