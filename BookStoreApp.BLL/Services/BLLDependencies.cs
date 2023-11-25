using BookStoreApp.BLL.Abstract;
using BookStoreApp.BLL.Concrete;
using BookStoreApp.BLL.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreApp.BLL.Services;

public static class BllDependencies
{
    public static void AddBllDependencies(this IServiceCollection service)
    {
        service.AddScoped<ICategoryService, CategoryManager>();
        service.AddScoped<IBookService, BookManager>();
        service.AddScoped<IAuthorService, AuthorManager>();
        service.AddAutoMapper(typeof(AuthorProfile), typeof(BookProfile), typeof(CategoryProfile));
    }
}