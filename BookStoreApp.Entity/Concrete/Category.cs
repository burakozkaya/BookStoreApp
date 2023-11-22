namespace BookStoreApp.Entity.Concrete;

public class Category : BaseEntity
{
    //create category properties
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }

    //Nav Property
    public List<Book> Books { get; set; }
}