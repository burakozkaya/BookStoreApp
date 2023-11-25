using BookStoreApp.DAL.Context;

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
        var dbContext = context.RequestServices.GetRequiredService<AppDbContext>();
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            dbContext.ErrorLogs.Add(new()
            {
                HttpMethod = context.Request.Method,
                Error = ex.Message,
                Path = context.Request.Path,
                Date = DateTime.UtcNow
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
