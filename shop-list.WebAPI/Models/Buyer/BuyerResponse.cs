namespace shopList.WebAPI.Models;
public class BuyerResponse
{
    public Guid Id{get;set;}
    public Datetime Birthday { get; set; }
    public int phoneNumber{get;set;}
    public Guid UserId{get;set;}
    
}