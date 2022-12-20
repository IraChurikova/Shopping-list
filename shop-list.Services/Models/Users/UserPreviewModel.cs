namespace shopList.Services.Models;
public class UserPreviewModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string firstName {get;set;}
    public string lastName {get;set;}
    public int? phoneNumber{get; set;}
    public string? login{get; set;}

}