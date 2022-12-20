using shopList.Entity.Models;
namespace shopList.Services.Models;
public class ProductListModel:BaseModel
{
    public Guid Id{get;set;}
    public virtual Guid BuyerId{get;set;}
    public virtual Guid ProductId{get;set;}
}