using FluentValidation;
using FluentValidation.Results;

namespace shopList.WebAPI.Models;

public class UpdateDescriptionRequest
{
    #region Model
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string Material { get; set; }
    public int Weight { get; set; }
    public int Size { get; set; }

    #endregion

    #region Validator
     public class Validator: AbstractValidator<UpdateDescriptionRequest>
     {
        public Validator()
        {
            RuleFor(x=>x.Country)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x=>x.Material)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x=>x.Weight)
               .NotNull().WithMessage("Length > 0");
            RuleFor(x=>x.Size)
               .NotNull().WithMessage("Length > 0");
        }

     }
     #endregion
}
public static class UpdateChannelRequestExtension
{
    public static ValidationResult Validate(this UpdateProductInStockRequest model)
    {
        return new UpdateProductInStockRequest.Validator().Validate(model);
    }
}