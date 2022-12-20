using shopList.Entity.Models;
namespace shopList.Services.Models;
 public class ProductInStockModel:BaseModel
 {
   public Guid Id{get;set;}
    public int? Count{get;set;}
    
 }