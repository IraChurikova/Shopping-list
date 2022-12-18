namespace shopList.Entity.Models;

public class Description:BaseEntity
{
    public string? Country{get; set;}
    public string? Material{get; set;}
    public string? Weight{get; set;}
    public string? Size{get; set;}
    public virtual ICollection<Product>? Products3 {get;set;}
}