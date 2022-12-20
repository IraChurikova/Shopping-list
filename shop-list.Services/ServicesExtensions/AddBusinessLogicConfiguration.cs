using shopList.Services.Abstract;
using shopList.Services.Implementation;
using shopList.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;
namespace shopList.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));
        //services
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBuyerService, BuyerService>();
        services.AddScoped<ISalesmenService, SalesmenService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductInStockService, ProductInStockService>();
        services.AddScoped<IProductListService, ProductListService>();
        services.AddScoped<IDescriptionService, DescriptionService>();
    }
}