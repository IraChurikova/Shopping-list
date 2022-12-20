using shopList.Services.Models;
namespace shopList.Services.Abstract;

public interface IProductService
{
    ProductModel GetProduct(Guid id);

    ProductModel UpdateProduct(Guid id, UpdateProductModel product);

    void DeleteProduct(Guid id);

    PageModel<ProductPreviewModel> GetProduct(int limit = 20, int offset = 0);
    ProductModel CreateProduct(ProductModel productModel);
}