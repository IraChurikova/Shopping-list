using AutoMapper;
using shopList.Entity.Models;
using shopList.Repository;
using shopList.Services.Abstract;
using shopList.Services.Models;

namespace shopList.Services.Implementation;

public class ProductService : IProductService
{
    private readonly IRepository<Product> ProductRepository;
    private readonly IMapper mapper;
    public ProductService(IRepository<Product> ProductRepository, IMapper mapper)
    {
        this.ProductRepository = ProductRepository;
        this.mapper = mapper;
    }

    public void DeleteProduct(Guid id)
    {
        var ProductToDelete =ProductRepository.GetById(id);
        if (ProductToDelete == null)
        {
            throw new Exception("Product not found");
        }
        ProductRepository.Delete(ProductToDelete);
    }

    public ProductModel GetProduct(Guid id)
    {
        var product =ProductRepository.GetById(id);
        return mapper.Map<ProductModel>(product);
    }

    public PageModel<ProductPreviewModel> GetProduct(int limit = 20, int offset = 0)
    {
        var product =ProductRepository.GetAll();
        int totalCount = product.Count();
        var chunk = Product.OrderBy(x => x.ChannelId).Skip(offset).Take(limit);

        return new PageModel<ProductPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<ProductPreviewModel>>(product),
            TotalCount = totalCount
        };
    }

    public ProductModel UpdateProduct(Guid id, UpdateProductModel product)
    {
        var existingProduct = ProductRepository.GetById(id);
        if (existingProduct == null)
        {
            throw new Exception("Product not found");
        }
        existingProduct =ProductRepository.Save(existingProduct);
        return mapper.Map<ProductModel>(existingProduct);
    }
    ProductModel IProductService.CreateProduct(CreateProductModel productModel)
    {
      var product= mapper.Map<Entity.Models.Product>(productModel);
       return mapper.Map<ProductModel>(ProductRepository.Save(product));
    }
}