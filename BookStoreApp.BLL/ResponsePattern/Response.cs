
namespace BookStoreApp.BLL.ResponsePattern;


public class Response
{
    public bool IsSuccess { get; protected set; }
    public string Message { get; protected set; }

    public static Response Success(string message)
    {
        return new Response() { IsSuccess = true, Message = message };
    }

    public static Response Fail(string message)
    {
        return new Response() { IsSuccess = false, Message = message };
    }
}

public class Response<T> : Response
{
    public T? Data { get; protected set; }

    public static Response<T> Success(T data, string message)
    {
        return new Response<T>() { IsSuccess = true, Message = message, Data = data };
    }

    public static Response<T> Fail(string message)
    {
        return new Response<T>() { IsSuccess = false, Message = message };
    }
}