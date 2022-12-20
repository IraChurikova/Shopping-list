using shopList.Services.Models;
namespace shopList.Services.Abstract;

public interface IDescriptionService
{
    DescriptionModel GetDescription(Guid id);

    DescriptionModel UpdateDescription(Guid id, UpdateDescriptionModel description);

    void DeleteDescription(Guid id);

    PageModel<DescriptionPreviewModel> GetDescription(int limit = 20, int offset = 0);
    DescriptionModel CreateDescription(CreateDescriptionModel description);
}