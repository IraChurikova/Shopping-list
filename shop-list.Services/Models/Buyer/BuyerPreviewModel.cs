namespace shopList.Services.Models;
public class BuyerPreviewModel
{
    public Guid Id{get;set;}
    public int phoneNumber{get;set;}
    public DateTime Birthday{get;set;}
    public virtual Guid UserId{get;set;}
}

