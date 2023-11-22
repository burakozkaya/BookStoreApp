using BookStoreApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.DAL.Context;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

}