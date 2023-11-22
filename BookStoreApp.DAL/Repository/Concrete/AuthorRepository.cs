using BookStoreApp.DAL.Context;
using BookStoreApp.DAL.Repository.Abstract;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApp.DAL.Repository.Concrete;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }
}