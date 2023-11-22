using BookStoreApp.Entity.Abstract;

namespace BookStoreApp.Entity.Concrete;

public class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool IsActive { get; set; }
}