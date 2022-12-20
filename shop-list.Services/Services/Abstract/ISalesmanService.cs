using shopList.Services.Models;
namespace shopList.Services.Abstract;

public interface ISalesmenService
{
    SalesmenModel GetSalesmen(Guid id);

    SalesmenModel UpdateSalesmen(Guid id, UpdateSalesmenModel salesmen);

    void DeleteSalesmen(Guid id);

    PageModel<SalesmenPreviewModel> GetSalesmen(int limit = 20, int offset = 0);
    SalesmenModel CreateSalesmen(CreateSalesmenModel salesmenModel);
}