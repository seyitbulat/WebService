using Microsoft.Extensions.DependencyInjection;
using WS.Business.Implementations;
using WS.Business.Interfaces;
using WS.DataAccsess.EF.Repositories;
using WS.DataAccsess.Interfaces;

namespace WS.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(WS.Business.Profiles.AutoMapperProfile));


            services.AddScoped<IProductBs, ProductBs>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryBs, CategoryBs>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ISupplierBs, SupplierBs>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            services.AddScoped<ICustomerBs, CustomerBs>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IEmployeeBs, EmployeeBs>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IShipperBs, ShipperBs>();
            services.AddScoped<IShipperRepository, ShipperRepository>();
        }
    }
}
