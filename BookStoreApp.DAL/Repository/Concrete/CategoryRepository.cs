using BookStoreApp.DAL.Context;
using BookStoreApp.DAL.Repository.Abstract;
using BookStoreApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.DAL.Repository.Concrete;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
    public override async Task<Category?> GetByIdAsync(int id)
    {
        return await _dbSet.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
    }

    public override async Task<List<Category>> GetAllIncludingAllAsync()
    {
        return await _dbSet.Where(x => x.IsActive).Include(x => x.Books).Select(x => new Category()
        {
            Id = x.Id,
            IsActive = x.IsActive,
            Name = x.Name,
            Books = x.Books.Where(x => x.IsActive).ToList()
        }).ToListAsync();
    }
}