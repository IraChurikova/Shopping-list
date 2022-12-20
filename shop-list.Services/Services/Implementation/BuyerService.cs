using AutoMapper;
using shopList.Entity.Models;
using shopList.Repository;
using shopList.Services.Abstract;
using shopList.Services.Models;

namespace shopList.Services.Implementation;

public class BuyerService :IBuyerService
{
    private readonly IRepository<Buyer> buyerRepository;
    private readonly IMapper mapper;
    public BuyerService(IRepository<Buyer> buyerRepository, IMapper mapper)
    {
        this.buyerRepository = buyerRepository;
        this.mapper = mapper;
    }

    public void DeleteBuyer(Guid id)
    {
        var buyerToDelete = buyerRepository.GetById(id);
        if (buyerToDelete == null)
        {
            throw new Exception("Buyer not found");
        }
        buyerRepository.Delete(buyerToDelete);
    }

    public buyerModel GetBuyer(Guid id)
    {
        var buyer =buyerRepository.GetById(id);
        return mapper.Map<BuyerModel>(buyer);
    }

    public PageModel<buyerPreviewModel> GetBuyers(int limit = 20, int offset = 0)
    {
        var buyer =buyerRepository.GetAll();
        int totalCount =buyer.Count();
        var chunk=buyer.OrderBy(x=>x.Name).Skip(offset).Take(limit);

        return new PageModel<buyerPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<buyerPreviewModel>>(buyer),
            TotalCount = totalCount
        };
    }

    public BuyerModel UpdateBuyer(Guid id, UpdateBuyerModel buyer)
    {
        var existingBuyer = buyerRepository.GetById(id);
        if (existingBuyer == null)
        {
            throw new Exception("Buyer not found");
        }
        existingBuyer.Name=buyer.Name;
        existingBuyer = buyerRepository.Save(existingBuyer);
        return mapper.Map<buyerModel>(existingBuyer);
    }
    BuyerModel IBuyerService.CreateBuyer(BuyerModel buyerModel)
    {
       BuyerRepository.Save(mapper.Map<Entity.Models.Buyer>(buyerModel));
        return buyerModel;
    }
}