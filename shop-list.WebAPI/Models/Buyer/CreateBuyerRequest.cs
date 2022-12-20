namespace shopList.WebAPI.Models;
public class CreateBuyerRequest:UpdateBuyerRequest
{
    public Guid UserId{get;set;}

}