using shopList.Services.Models;
namespace shopList.Services.Abstract;

public interface IProductInStockService
{
    ProductInStockModel GetProductInStock(Guid id);

    ProductInStockModel UpdateProductInStock(Guid id, UpdateProductInStockModel productInStock);

    void DeleteProductInStock(Guid id);

    PageModel<ProductInStockPreviewModel> GetProductInStock(int limit = 20, int offset = 0);
    ProductInStockModel CreateProductInStock(CreateProductInStockModel productInStock);
}