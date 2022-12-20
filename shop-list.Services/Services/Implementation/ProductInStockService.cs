using AutoMapper;
using shopList.Entity.Models;
using shopList.Repository;
using shopList.Services.Abstract;
using shopList.Services.Models;

namespace shopList.Services.Implementation;

public class ProductInStockService : IProductInStockService
{
    private readonly IRepository<ProductInStock> ProductInStocksRepository;
    private readonly IMapper mapper;
    public ProductInStockService(IRepository<ProductInStock> productInStocksRepository, IMapper mapper)
    {
        this.ProductInStocksRepository = productInStocksRepository;
        this.mapper = mapper;
    }

    public void DeleteProductInStock(Guid id)
    {
        var productInStockToDelete = ProductInStocksRepository.GetById(id);
        if (productInStockToDelete == null)
        {
            throw new Exception("ProductInStock not found");
        }

        ProductInStocksRepository.Delete(productInStockToDelete);
    }

    public ProductInStockModel GetProductInStock(Guid id)
    {
        var productInStock = ProductInStocksRepository.GetById(id);
        return mapper.Map<ProductInStockModel>(productInStock);
    }

    public PageModel<ProductInStockPreviewModel> GetProductInStocks(int limit = 20, int offset = 0)
    {
        var productInStocks = ProductInStocksRepository.GetAll();
        int totalCount = productInStocks.Count();
        var chunk = ProductInStocks.OrderBy(x => x.Email).Skip(offset).Take(limit);

        return new PageModel<ProductInStockPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<ProductInStockPreviewModel>>(productInStocks),
            TotalCount = totalCount
        };
    }

    public ProductInStockModel UpdateProductInStock(Guid id, UpdateProductInStockModel productInStock)
    {
        var existingProductInStock = ProductInStocksRepository.GetById(id);
        if (existingProductInStock == null)
        {
            throw new Exception("ProductInStock not found");
        }
        existingProductInStock.Name=productInStock.Name;
        existingProductInStock = ProductInStocksRepository.Save(existingProductInStock);
        return mapper.Map<ProductInStockModel>(existingProductInStock);
    }
   
}