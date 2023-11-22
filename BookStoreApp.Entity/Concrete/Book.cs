namespace BookStoreApp.Entity.Concrete;

public class Book : BaseEntity
{
    //create Book properties
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    //Nav Property
    public Author Author { get; set; }
    public Category Category { get; set; }
}