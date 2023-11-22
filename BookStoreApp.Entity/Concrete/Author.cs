namespace BookStoreApp.Entity.Concrete;

public class Author : BaseEntity
{
    //create author properties
    //create author properties
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }

    //Nav Property
    public List<Book> Books { get; set; }
}