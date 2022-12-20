using FluentValidation;
using FluentValidation.Results;

namespace shopList.WebAPI.Models;

public class UpdateSalesmenRequest
{
    #region Model

    #endregion

    #region Validator
     public class Validator: AbstractValidator<UpdateSalesmenRequest>
     {
        public Validator()
        {
           
        }

     }
     #endregion
}
public static class UpdateChannelRequestExtension
{
    public static ValidationResult Validate(this UpdateSalesmenRequest model)
    {
        return new UpdateSalesmenRequest.Validator().Validate(model);
    }
}