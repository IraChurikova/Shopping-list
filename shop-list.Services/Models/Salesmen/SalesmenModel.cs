using shopList.Entity.Models;
namespace shopList.Services.Models;
public class SalesmenModel:BaseModel
{
    public Guid Id{get;set;}
    public virtual Guid UserId{get;set;}
}