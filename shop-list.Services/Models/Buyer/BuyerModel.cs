using shopList.Entity.Models;
namespace shopList.Services.Models;
public class BuyerModel:BaseModel
{
    public Guid Id{get;set;}
    public int phoneNumber{get;set;}
    public DateTime Birthday{get;set;}
    public virtual Guid UserId{get;set;}
}