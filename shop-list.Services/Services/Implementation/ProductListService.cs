using AutoMapper;
using shopList.Entity.Models;
using shopList.Repository;
using shopList.Services.Abstract;
using shopList.Services.Models;

namespace shopList.Services.Implementation;

public class ProductListService : IProductListService
{
    private readonly IRepository<ProductList> productListRepository;
    private readonly IMapper mapper;
    public ProductListService(IRepository<ProductList> productListRepository, IMapper mapper)
    {
        this.ProductListRepository = productListRepository;
        this.mapper = mapper;
    }

    public void DeleteProductList(Guid id)
    {
        var ProductListToDelete =ProductListRepository.GetById(id);
        if (ProductListToDelete == null)
        {
            throw new Exception("ProductList not found");
        }
        ProductListRepository.Delete(productListToDelete);
    }

    public ProductListModel GetProductList(Guid id)
    {
        var ProductList =ProductListRepository.GetById(id);
        return mapper.Map<ProductListModel>(ProductList);
    }

    public PageModel<ProductListPreviewModel> GetProductList(int limit = 20, int offset = 0)
    {
        var ProductList =ProductListRepository.GetAll();
        int totalCount = ProductList.Count();
        var chunk = ProductList.OrderBy(x => x.ChannelId).Skip(offset).Take(limit);

        return new PageModel<ProductListPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<ProductListPreviewModel>>(productList),
            TotalCount = totalCount
        };
    }

    public ProductListModel UpdateProductList(Guid id, UpdateProductListModel productList)
    {
        var existingProductList = ProductListRepository.GetById(id);
        if (existingProductList == null)
        {
            throw new Exception("ProductList not found");
        }
        existingProductList =ProductListRepository.Save(existingProductList);
        return mapper.Map<ProductListModel>(existingProductList);
    }
    ProductListModel IProductListService.CreateProductList(CreateProductListModel productListModel)
    {
      var ProductList= mapper.Map<Entity.Models.ProductList>(productListModel);
       return mapper.Map<ProductListModel>(ProductListRepository.Save(productList));
    }
}