namespace shopList.WebAPI.Models;
public class CreateProductListRequest: UpdateProductListRequest
{
    public Guid BuyerId{get;set;}
    public Guid ProductId{get;set;}

}