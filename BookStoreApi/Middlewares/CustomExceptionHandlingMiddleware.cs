using BookStoreApp.DAL.Context;
using BookStoreApp.Entity.Concrete;

namespace BookStoreApi.Middlewares;

public class CustomExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public CustomExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var dbcontext = context.RequestServices.GetRequiredService<AppDbContext>();
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var errorLog = new AppErrorLog()
            {
                Error = ex.Message,
                Path = context.Request.Path,
                Date = DateTime.UtcNow
            };
            dbcontext.ErrorLogs.Add(errorLog);
            try
            {
                await dbcontext.SaveChangesAsync();
            }
            catch
            {
                //loglama işlemi hatalarını yakalamak için
            }
        }
    }

}
