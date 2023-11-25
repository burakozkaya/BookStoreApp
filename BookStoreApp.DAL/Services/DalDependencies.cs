using BookStoreApp.DAL.Context;
using BookStoreApp.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreApp.DAL.Services
{
    public static class DalDependencies
    {
        public static void AddDalDependency(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            service.AddScoped<IUow, Uow>();

        }
    }
}
