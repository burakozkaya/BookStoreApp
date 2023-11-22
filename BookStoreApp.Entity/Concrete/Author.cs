namespace BookStoreApp.Entity.Concrete;

public class Author : BaseEntity
{
    public string Name { get; set; }

    //Nav Property
    public List<Book> Books { get; set; }
}