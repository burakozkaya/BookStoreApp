using BookStoreApp.DAL.Context;
using BookStoreApp.DAL.Repository.Abstract;
using BookStoreApp.Entity.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.DAL.Repository.Concrete;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        _dbSet.Where(x => x.IsActive == true);
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public async Task RemoveAsync(int id)
    {
        var tempData = await _dbSet.FindAsync(id);
        _dbSet.Remove(tempData);
    }
}