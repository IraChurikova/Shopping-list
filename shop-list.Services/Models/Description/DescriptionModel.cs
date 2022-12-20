using shopList.Entity.Models;
namespace shopList.Services.Models;
 public class DescriptionModel:BaseModel
 {
   public Guid Id{get;set;}
    public string? Country{get;set;}
    public string? Material{get;set;}
    public int? Weight{get;set;}
    public int? Size{get;set;}
    
 }