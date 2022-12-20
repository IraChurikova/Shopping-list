using AutoMapper;
using shopList.Entity.Models;
using shopList.Repository;
using shopList.Services.Abstract;
using shopList.Services.Models;

namespace shopList.Services.Implementation;

public class DescriptionService : IDescriptionService
{
    private readonly IRepository<Description> DescriptionsRepository;
    private readonly IMapper mapper;
    public DescriptionService(IRepository<Description> descriptionsRepository, IMapper mapper)
    {
        this.DescriptionsRepository = descriptionsRepository;
        this.mapper = mapper;
    }

    public void DeleteDescription(Guid id)
    {
        var descriptionToDelete = DescriptionsRepository.GetById(id);
        if (descriptionToDelete == null)
        {
            throw new Exception("Description not found");
        }

        DescriptionsRepository.Delete(descriptionToDelete);
    }

    public DescriptionModel GetDescription(Guid id)
    {
        var description = DescriptionsRepository.GetById(id);
        return mapper.Map<DescriptionModel>(description);
    }

    public PageModel<DescriptionPreviewModel> GetDescriptions(int limit = 20, int offset = 0)
    {
        var descriptions = DescriptionsRepository.GetAll();
        int totalCount = descriptions.Count();
        var chunk = Descriptions.OrderBy(x => x.Email).Skip(offset).Take(limit);

        return new PageModel<DescriptionPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<DescriptionPreviewModel>>(descriptions),
            TotalCount = totalCount
        };
    }

    public DescriptionModel UpdateDescription(Guid id, UpdateDescriptionModel description)
    {
        var existingDescription = DescriptionsRepository.GetById(id);
        if (existingDescription == null)
        {
            throw new Exception("Description not found");
        }
        existingDescription.Name=description.Name;
        existingDescription = DescriptionsRepository.Save(existingDescription);
        return mapper.Map<DescriptionModel>(existingDescription);
    }
   
}