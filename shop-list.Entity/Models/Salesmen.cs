namespace shopList.Entity.Models;

public class Salesmen:BaseEntity
{
   public virtual  User? User{get;set;}
    public virtual  int? UserId{get;set;}
    public virtual ICollection<Product>? Products1 {get;set;}
}