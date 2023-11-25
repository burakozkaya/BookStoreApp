using BookStoreApi.Middlewares;
using BookStoreApp.BLL.Services;
using BookStoreApp.DAL.Services;

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
            var conString = builder.Configuration.GetConnectionString("DevConnection");

            builder.Services.AddDalDependency(conString);

            builder.Services.AddBllDependencies();
            //enable cors for my localhost https://localhost:7060/
            var localHost = builder.Configuration.GetSection("WebAppCors:HostPort").Value;
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                       policyBuilder => policyBuilder.WithOrigins(localHost)
                                                          .AllowAnyMethod()
                                                          .AllowAnyHeader()
                                                          .AllowCredentials());
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<CustomExceptionHandlingMiddleware>();

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
