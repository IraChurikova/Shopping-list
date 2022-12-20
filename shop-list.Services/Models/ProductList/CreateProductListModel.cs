
namespace shopList.Services.Models;
public class CreateProductListModel
{
    public Guid Id{get;set;}
    public virtual Guid BuyerId{get;set;}
    public virtual Guid ProductId{get;set;}
}