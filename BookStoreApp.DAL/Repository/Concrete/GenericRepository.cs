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

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.Where(x => x.IsActive).ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
    }

    public async Task AddAsync(T entity)
    {
        entity.IsActive = true;
        await _dbSet.AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {

        var temp = _dbSet.Find(entity.Id);
        _context.Entry(temp).State = EntityState.Detached;
        entity.IsActive = temp!.IsActive;
        //foreach (var propertyInfo in typeof(IBaseEntity).GetProperties())
        //{
        //    if (propertyInfo.Name != "Id")
        //    {
        //        var tempD = temp.GetType().GetProperty(propertyInfo.Name).GetValue(temp);
        //        entity.GetType().GetProperty(propertyInfo.Name)!.SetValue(entity, tempD);
        //    }
        //}
        //_context.Entry(temp).State = EntityState.Detached;
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public async Task RemoveAsync(int id)
    {
        var tempData = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        tempData.IsActive = false;
    }
    public virtual async Task<List<T>> GetAllIncludingAllAsync()
    {
        var query = _dbSet.AsQueryable();

        var navigationProperties = _context.Model.FindEntityType(typeof(T))
            ?.GetNavigations()
            .Select(e => e.Name);

        foreach (var propertyName in navigationProperties)
        {
            query = query.Include(propertyName);
        }

        return await query.Where(x => x.IsActive).ToListAsync();
    }

}