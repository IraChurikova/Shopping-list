using shopList.Entity.Models;
namespace shopList.Services.Models;
 public class UserModel:BaseModel
 {
    public Guid Id { get; set; }
    public string firstName {get;set;}
    public string lastName {get;set;}
    public string? Email{get; set;}
    public string? phoneNumber{get; set;}
    public string? login{get; set;}
   
 }