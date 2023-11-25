using BookStoreApi.Middlewares;

public static class MyExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorLogToDb(this IApplicationBuilder app)
    {
        return app.UseMiddleware<CustomExceptionHandlingMiddleware>();
    }
}
