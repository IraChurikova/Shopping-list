using FluentValidation;
using FluentValidation.Results;

namespace shopList.WebAPI.Models;

public class UpdateProductListRequest
{
    #region Model

    #endregion

    #region Validator
     public class Validator: AbstractValidator<UpdateProductListRequest>
     {
        public Validator()
        {
           
        }

     }
     #endregion
}
public static class UpdateChannelRequestExtension
{
    public static ValidationResult Validate(this UpdateProductListRequest model)
    {
        return new UpdateProductListRequest.Validator().Validate(model);
    }
}