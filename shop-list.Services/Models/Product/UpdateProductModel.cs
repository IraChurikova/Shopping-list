using shopList.Entity.Models;
namespace shopList.Services.Models;
public class UpdateProductModel
{
    public Guid Id{get;set;}
    public string Name {get;set;}
    public int Price {get;set;}
    public virtual Guid SalesmenId{get;set;}
    public virtual Guid ProductInStockId{get;set;}
    public virtual Guid DescriptionId{get;set;}
}