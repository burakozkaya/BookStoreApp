using BookStoreApp.DAL.Repository.Abstract;

namespace BookStoreApp.DAL.UnitOfWork;

public interface IUow
{
    Task<int> SaveAsync();
    IBookRepository BookRepository { get; }
    IAuthorRepository AuthorRepository { get; }
    ICategoryRepository CategoryRepository { get; }
}