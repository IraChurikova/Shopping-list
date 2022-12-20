using shopList.Services.Models;
namespace shopList.Services.Abstract;

public interface IBuyerService
{
    BuyerModel GetBuyer(Guid id);

    BuyerModel UpdateBuyer(Guid id, UpdateBuyerModel buyer);

    void DeleteBuyer(Guid id);

    PageModel<BuyerPreviewModel> GetBuyer(int limit = 20, int offset = 0);
    BuyerModel CreateBuyer(BuyerModel buyerModel);
}