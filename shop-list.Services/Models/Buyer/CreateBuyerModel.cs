
namespace shopList.Services.Models;
public class CreateBuyerModel
{

    public Guid Id{get;set;}
    public int phoneNumber{get;set;}
    public DateTime Birthday{get;set;}
    public virtual Guid UserId{get;set;}
}