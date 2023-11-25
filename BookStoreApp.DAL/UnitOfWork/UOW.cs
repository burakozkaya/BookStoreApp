using BookStoreApp.DAL.Context;
using BookStoreApp.DAL.Repository.Abstract;
using BookStoreApp.DAL.Repository.Concrete;
using BookStoreApp.Entity.Abstract;

namespace BookStoreApp.DAL.UnitOfWork;

public class Uow : IUow, IDisposable
{
    private readonly AppDbContext _context;
    private ICategoryRepository? _categoryRepository;
    private IAuthorRepository? _authorRepository;
    private IBookRepository? _bookRepository;
    public Uow(AppDbContext context)
    {
        _context = context;
    }

    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);
    public IGenericRepository<T> GetGenericRepository<T>() where T : class, IBaseEntity
    {
        return new GenericRepository<T>(_context);
    }

    public IAuthorRepository AuthorRepository => _authorRepository ??= new AuthorRepository(_context);

    public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_context);

    public void Dispose() => _context.Dispose();

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}