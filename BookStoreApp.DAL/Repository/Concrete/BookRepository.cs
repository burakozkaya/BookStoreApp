using BookStoreApp.DAL.Context;
using BookStoreApp.DAL.Repository.Abstract;
using BookStoreApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.DAL.Repository.Concrete;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<List<Book>> GetAllAsync()
    {
        return await _dbSet.Where(x => x.IsActive)
                           .Include(x => x.Author)
                           .Include(x => x.Category)
                           .ToListAsync();
    }

    public override async Task<Book?> GetByIdAsync(int id)
    {
        return await _dbSet.Where(x => x.IsActive)
                           .Include(x => x.Author)
                           .Include(x => x.Category)
                           .FirstOrDefaultAsync(x => x.Id == id);
    }
}