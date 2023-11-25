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
}