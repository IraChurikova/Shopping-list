using AutoMapper;
using shopList.Entity.Models;
using shopList.Repository;
using shopList.Services.Abstract;
using shopList.Services.Models;

namespace shopList.Services.Implementation;

public class SalesmenService : ISalesmenService
{
    private readonly IRepository<Salesmena> SalesmenRepository;
    private readonly IMapper mapper;
    public SalesmenService(IRepository<Salesmena> salesmenRepository, IMapper mapper)
    {
        this.SalesmenRepository = salesmenRepository;
        this.mapper = mapper;
    }

    public void DeleteSalesmen(Guid id)
    {
        var SalesmenToDelete = salesmenRepository.GetById(id);
        if (salesmenToDelete == null)
        {
            throw new Exception("Salesmen not found");
        }
        SalesmenRepository.Delete(salesmenToDelete);
    }

    public SalesmenModel GetSalesmen(Guid id)
    {
        var Salesmen = SalesmenRepository.GetById(id);
        return mapper.Map<SalesmenModel>(salesmen);
    }

    public PageModel<SalesmenPreviewModel> GetSalesmens(int limit = 20, int offset = 0)
    {
        var salesmens = SalesmenRepository.GetAll();
        int totalCount = salesmens.Count();
        var chunk = salesmens.OrderBy(x => x.ChannelId).Skip(offset).Take(limit);
        

        return new PageModel<SalesmenPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<SalesmenPreviewModel>>(salesmens),
            TotalCount = totalCount
        };
    }

    public SalesmenModel UpdateSalesmen(Guid id, UpdateSalesmenModel salesmen)
    {
        var existingSalesmen =SalesmenRepository.GetById(id);
        if (existingSalesmen == null)
        {
            throw new Exception("Salesmen not found");
        }
        existingSalesmen.Name=salesmen.Name;
        existingSalesmen.Duration=salesmen.Duration;
        existingSalesmen.Time=salesmen.Time;
        existingSalesmen = SalesmenRepository.Save(existingSalesmen);
        return mapper.Map<SalesmenModel>(existingSalesmen);
    }
    SalesmenModel ISalesmenService.CreateSalesmen(CreateSalesmenModel salesmenModel)
    {
      var salesmen= mapper.Map<Entity.Models.Salesmena>(salesmenModel);
       return mapper.Map<salesmenModel>(SalesmenRepository.Save(salesmen));
    }
}
