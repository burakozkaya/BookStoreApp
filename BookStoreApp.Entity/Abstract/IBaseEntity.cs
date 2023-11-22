namespace BookStoreApp.Entity.Abstract;

public interface IBaseEntity
{
    //create a base entity interface
    public int Id { get; set; }
    public bool IsActive { get; set; }
}