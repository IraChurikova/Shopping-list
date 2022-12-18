 namespace shopList.Entity.Models;

public class ProductList:BaseEntity
{
    public Buyer ? Buyer{get;set;}
    public virtual  int? BuyerId{get;set;}
    public Product? Product{get;set;}// cписок
    public virtual  int? ProductId{get;set;}
}