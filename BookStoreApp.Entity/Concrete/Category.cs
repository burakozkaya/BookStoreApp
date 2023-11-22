namespace BookStoreApp.Entity.Concrete;

public class Category : BaseEntity
{
    public string Name { get; set; }

    //Nav Property
    public List<Book> Books { get; set; }
}