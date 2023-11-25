using BookStoreApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.DAL.Context;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AppErrorLog> ErrorLogs { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "Author 1", IsActive = true },
            new Author { Id = 2, Name = "Author 2", IsActive = true },
            new Author { Id = 3, Name = "Author 3", IsActive = true }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Süper Kitap 1", Description = "Book 1", AuthorId = 1, CategoryId = 1, Price = 1500, Stock = 15, IsActive = true },
            new Book { Id = 2, Title = "Süper Kitap 2", Description = "Book 2", AuthorId = 2, CategoryId = 2, Price = 1500, Stock = 15, IsActive = true },
            new Book { Id = 3, Title = "Süper Kitap 3", Description = "Book 3", AuthorId = 3, CategoryId = 3, Price = 1500, Stock = 15, IsActive = true }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Category 1", IsActive = true },
            new Category { Id = 2, Name = "Category 2", IsActive = true },
            new Category { Id = 3, Name = "Category 3", IsActive = true }
        );

        base.OnModelCreating(modelBuilder);
    }
}