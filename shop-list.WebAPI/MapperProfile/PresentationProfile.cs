using AutoMapper;
using shopList.WebAPI.Models;
using shopList.Services.Models;

namespace shopList.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region Pages

        CreateMap(typeof(PageModel<>),typeof(PageResponse<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>().ReverseMap();
        CreateMap<UpdateUserRequest, UpdateUserModel>().ReverseMap();
        CreateMap<UserPreviewModel, UserPreviewResponse>().ReverseMap();
        CreateMap<UserResponse, UserPreviewModel>().ReverseMap();
        
        #endregion

        #region Buyers

        CreateMap<BuyerModel, BuyerResponse>().ReverseMap();
        CreateMap<UpdateBuyerRequest, UpdateBuyerModel>().ReverseMap();
        CreateMap<BuyerPreviewModel, BuyerPreviewResponse>().ReverseMap();
        CreateMap<BuyerResponse, BuyerPreviewModel>().ReverseMap();
        
        #endregion

        #region Salesmens

        CreateMap<SalesmenModel, SalesmenResponse>().ReverseMap();
        CreateMap<UpdateSalesmenRequest, UpdateSalesmenModel>().ReverseMap();
        CreateMap<SalesmenPreviewModel, SalesmenPreviewResponse>().ReverseMap();
        CreateMap<SalesmenResponse, SalesmenPreviewModel>().ReverseMap();
        
        #endregion

        #region ProductList

        CreateMap<ProductListModel, ProductListResponse>().ReverseMap();
        CreateMap<UpdateProductListRequest, UpdateProductListModel>().ReverseMap();
        CreateMap<ProductListPreviewModel, ProductListPreviewResponse>().ReverseMap();
        CreateMap<ProductListResponse, ProductListPreviewModel>().ReverseMap();
        
        #endregion

        #region Product

        CreateMap<ProductModel, ProductResponse>().ReverseMap();
        CreateMap<UpdateProductRequest, UpdateProductModel>().ReverseMap();
        CreateMap<ProductPreviewModel, ProductPreviewResponse>().ReverseMap();
        CreateMap<ProductResponse, ProductPreviewModel>().ReverseMap();
        
        #endregion

         #region ProductInStock

        CreateMap<ProductInStockModel, ProductInStockResponse>().ReverseMap();
        CreateMap<UpdateProductInStockRequest, UpdateProductInStockModel>().ReverseMap();
        CreateMap<ProductInStockPreviewModel, ProductInStockPreviewResponse>().ReverseMap();
        CreateMap<ProductInStockResponse, ProductInStockPreviewModel>().ReverseMap();
        
        #endregion

          #region Description

        CreateMap<DescriptionModel, DescriptionResponse>().ReverseMap();
        CreateMap<UpdateDescriptionRequest, UpdateDescriptionModel>().ReverseMap();
        CreateMap<DescriptionPreviewModel, DescriptionPreviewResponse>().ReverseMap();
        CreateMap<DescriptionResponse, DescriptionPreviewModel>().ReverseMap();
        
        #endregion

        #region Admin

        CreateMap<AdminModel, AdminResponse>().ReverseMap();
        CreateMap<UpdateAdminRequest, UpdateAdminModel>().ReverseMap();
        CreateMap<AdminPreviewModel, AdminPreviewResponse>().ReverseMap();
        CreateMap<AdminResponse, AdminPreviewModel>().ReverseMap();
        
        #endregion

    }
}
