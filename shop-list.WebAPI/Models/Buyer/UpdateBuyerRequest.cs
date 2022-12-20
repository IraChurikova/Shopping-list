using FluentValidation;
using FluentValidation.Results;

namespace shopList.WebAPI.Models;

public class UpdateBuyerRequest
{
    #region Model
    public Guid Id { get; set; }
    public Datetime Birthday { get; set; }
    public int phoneNumber{get;set;}

    #endregion

    #region Validator
     public class Validator: AbstractValidator<UpdateBuyerRequest>
     {
        public Validator()
        {
            RuleFor(x=>x.Birthday)
                .InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
            RuleFor(x=>x.phoneNumber)
               .NotNull().WithMessage("Length > 0");
        }

     }
     #endregion
}
public static class UpdateBuyerRequestExtension
{
    public static ValidationResult Validate(this UpdateBuyerRequest model)
    {
        return new UpdateBuyerRequest.Validator().Validate(model);
    }
}