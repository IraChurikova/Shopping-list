using shopList.Services.Models;
namespace shopList.Services.Abstract;

public interface IProductListService
{
    ProductListModel GetProductList(Guid id);

    ProductListModel UpdateProductList(Guid id, UpdateProductListModel productList);

    void DeleteProductList(Guid id);

    PageModel<ProductListPreviewModel> GetProductList(int limit = 20, int offset = 0);
    ProductListModel CreateProductList(CreateProductListModel productList);
}