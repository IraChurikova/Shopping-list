using shopList.Entity.Models;
namespace shopList.Services.Models;
public class UpdateSalesmenModel
{
    public Guid Id{get;set;}
    public virtual Guid UserId{get;set;}
}