namespace shopList.WebAPI.Models;
public class CreateProductRequest:UpdateProgramRequest
{
    public Guid SalesmenId{get;set;}
    public Guid ProductInStockId{get;set;}
    public Guid DescriptionId{get;set;}
}