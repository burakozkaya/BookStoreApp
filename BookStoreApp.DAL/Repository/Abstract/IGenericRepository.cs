using BookStoreApp.Entity.Abstract;

namespace BookStoreApp.DAL.Repository.Abstract;

public interface IGenericRepository<T> where T : class, IBaseEntity
{
    //write generic repository interface
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(int id);
}