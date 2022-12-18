namespace shopList.Entity.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime Birthday { get; set; }

    public bool IsNew()
    {
        return Id == Guid.Empty;
    }

    public void Init()
    {
        Id = Guid.NewGuid();
        Birthday = DateTime.UtcNow;
    }
}