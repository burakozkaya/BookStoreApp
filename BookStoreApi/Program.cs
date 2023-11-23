using BookStoreApp.BLL.Abstract;
using BookStoreApp.BLL.Concrete;
using BookStoreApp.BLL.Mapping;
using BookStoreApp.DAL.Context;
using BookStoreApp.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
            builder.Services.AddScoped<IUOW, UOW>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<IBookService, BookManager>();
            builder.Services.AddScoped<IAuthorService, AuthorManager>();
            builder.Services.AddAutoMapper(typeof(AuthorProfile), typeof(BookProfile), typeof(CategoryProfile));
            //enable cors for my localhost https://localhost:7060/
            var localHost = builder.Configuration.GetSection("WebAppCors:HostPort").Value;
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                       builder => builder.WithOrigins(localHost)
                                                          .AllowAnyMethod()
                                                          .AllowAnyHeader()
                                                          .AllowCredentials());
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
