using FluentValidation;
using FluentValidation.Results;

namespace shopList.WebAPI.Models;

public class UpdateProgramRequest
{
    #region Model
    public Guid Id { get; set; }
     public string Name { get; set; }
    public int Price{get;set;}

    #endregion

    #region Validator
     public class Validator: AbstractValidator<UpdateProgramRequest>
     {
        public Validator()
        {
            RuleFor(x=>x.Name)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x=>x.Price)
               .NotNull().WithMessage("Length > 0");
        }

     }
     #endregion
}
public static class UpdateProgramRequestExtension
{
    public static ValidationResult Validate(this UpdateProgramRequest model)
    {
        return new UpdateProgramRequest.Validator().Validate(model);
    }
}