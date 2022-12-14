namespace shopList.Entity.Models;

public class User:BaseEntity
{
    public string? Login{get; set;}
    public string? FirstName{get; set;}
    public string? LastName{get; set;}
    public string? PhoneNumber{get; set;}
    public string? Email{get; set;}
    public string? PasswordHash{get;set;}
    public virtual ICollection<Salesmen>? SalesmensList {get;set;}
    public virtual ICollection<Buyer>? BuyersList {get;set;}
   
    
}