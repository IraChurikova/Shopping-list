namespace shopList.Entity.Models;

public class ProductInStock:BaseEntity
{
     public string? Count{get; set;}
      public virtual ICollection<Product>? Products2 {get;set;}
}