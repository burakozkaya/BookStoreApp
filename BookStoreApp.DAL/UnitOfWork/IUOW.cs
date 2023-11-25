using BookStoreApp.DAL.Repository.Abstract;
using BookStoreApp.Entity.Abstract;

namespace BookStoreApp.DAL.UnitOfWork;

public interface IUow
{
    Task<int> SaveAsync();
    IBookRepository BookRepository { get; }
    IAuthorRepository AuthorRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IGenericRepository<T> GetGenericRepository<T>() where T : class, IBaseEntity;

}