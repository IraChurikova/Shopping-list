using AutoMapper;
using shopList.Entity.Models;
using shopList.Services.Models;

namespace shopList.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {

        #region Admin

        
        CreateMap<Admin, AdminModel>().ReverseMap();
        CreateMap<Admin, AdminPreviewModel>()
            .ForMember(x => x.Login, y => y.MapFrom(u => u.Login));

        #endregion
        #region Users

        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserPreviewModel>()
            .ForMember(x => x.firstName, y => y.MapFrom(u => u.firstName))
            .ForMember(x => x.lastName, y => y.MapFrom(u => u.lastName))
            .ForMember(x => x.phoneNumber, y => y.MapFrom(u => u.phoneNumber))
            .ForMember(x => x.Email, y => y.MapFrom(u => u.Email));

        #endregion

        #region Description

        CreateMap<Description, DescriptionModel>().ReverseMap();
        CreateMap<Descriptionl, DescriptionPreviewModel>()
            .ForMember(x => x.Country, y => y.MapFrom(u => u.Country))
            .ForMember(x => x.Material, y => y.MapFrom(u => u.Material))
            .ForMember(x => x.Weight, y => y.MapFrom(u => u.Weight))
            .ForMember(x => x.Size, y => y.MapFrom(u => u.Size));
        #endregion

        #region ProductInStock

        CreateMap<ProductInSrock, ProductInSrockModel>().ReverseMap();
        CreateMap<ProductInSrock, ProductInSrockPreviewModel>()
            .ForMember(x => x.Count, y => y.MapFrom(u => u.Count));

        #endregion
        #region Buyer

        CreateMap<Buyer, BuyerModel>().ReverseMap();
        CreateMap<Buyer, BuyerPreviewModel>()
            .ForMember(x => x.phoneNumber, y => y.MapFrom(u => u.phoneNumber))
            .ForMember(x => x.Birthday, y => y.MapFrom(u => u.Birthday));

        #endregion

        #region ProductList

        CreateMap<ProductList, ProductListModel>().ReverseMap();
        CreateMap<ProductList, ProductListPreviewModel>();
        #endregion

          #region Salesmen

        CreateMap<Salesmen, SalesmenModel>().ReverseMap();
        CreateMap<Salesmen, SalesmenPreviewModel>();
        #endregion

        #region Product

        CreateMap<Product, ProductModel>().ReverseMap();
        CreateMap<Product, ProductPreviewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.Price, y => y.MapFrom(u => u.Price));

        #endregion
        
    }
}

