namespace BookStoreApp.Entity.Concrete;

public class AppErrorLog
{
    public int Id { get; set; }
    public string Path { get; set; }
    public string HttpMethod { get; set; }
    public string Error { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}