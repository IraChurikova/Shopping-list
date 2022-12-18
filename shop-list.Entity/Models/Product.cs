 namespace shopList.Entity.Models;

public class Product:BaseEntity
{
    string ? Name{get;set;}
    int ? Price{get;set;}
    public Salesmen ? Salesmen{get;set;}
    public virtual  int? SalesmenId{get;set;}
    public ProductInStock ? ProductInStock{get;set;}
    public virtual  int? ProductInStocksId{get;set;}
    public Description ? Description{get;set;}
    public virtual  int? DescriptionId{get;set;}
    public virtual ICollection<ProductList>? Products {get;set;}
}