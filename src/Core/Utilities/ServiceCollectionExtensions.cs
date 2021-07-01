using Core.Repositories.Ef;
using Core.Repositories.Ef.Interfaces;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMsSqlRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerStaffRepository, CustomerStaffRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
        }

        public static void AddBaseServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
