
namespace shopList.Services.Models;
public class CreateProductModel
{

    public Guid Id{get;set;}
    public string Name {get;set;}
    public int Price {get;set;}
    public virtual Guid SalesmenId{get;set;}
    public virtual Guid ProductInStockId{get;set;}
    public virtual Guid DescriptionId{get;set;}
}