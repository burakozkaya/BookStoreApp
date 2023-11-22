namespace BookStoreWeb.Models;

public class AuthorListVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> BookTitles { get; set; }
}