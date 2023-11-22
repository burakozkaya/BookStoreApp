namespace BookStoreWeb.Models;

public class CategoryListVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> BookTitles { get; set; }
}