using Repository;
using Service;

namespace ShoppingAppAPI.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection ApplicationServices(this IServiceCollection services
        , IConfiguration config)
    {

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IAccountService, AccountService>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartService, CartService>();

        services.AddScoped<ICartDetailRepository, CartDetailRepository>();
        services.AddScoped<ICartDetailService, CartDetailService>();

        return services;

    }
}