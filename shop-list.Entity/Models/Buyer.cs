namespace shopList.Entity.Models;

public class Buyer:BaseEntity
{
   // public DateTime ? Birthday{get;set;}
    public string ? PhoneNumber {get;set;}
    public User ? User{get;set;}
    public virtual  int? UserId{get;set;}
    public virtual ICollection<ProductList>? ProductLists {get;set;}
}