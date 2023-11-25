using BookStoreApp.DAL.Context;
using BookStoreApp.DAL.Repository.Abstract;
using BookStoreApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.DAL.Repository.Concrete;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<Author?> GetByIdAsync(int id)
    {
        return await _dbSet.Where(x => x.IsActive && x.Id == id).Include(x => x.Books).FirstOrDefaultAsync();
    }

    public override async Task<List<Author>> GetAllIncludingAllAsync()
    {
        return await _dbSet
            .Where(x => x.IsActive)
            .Select(x => new Author
            {
                Id = x.Id,
                Name = x.Name,
                Books = x.Books.Where(book => book.IsActive).ToList()
            })
            .ToListAsync();
    }

}