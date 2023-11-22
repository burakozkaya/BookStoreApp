namespace BookStoreApp.Entity.Abstract;

public interface IBaseEntity
{
    //create a base entity interface
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool IsActive { get; set; }
}