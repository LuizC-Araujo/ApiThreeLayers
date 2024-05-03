using DevIO.Business.Interfaces;
using DevIO.Business.Notifications;
using DevIO.Business.Services;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.Api.Configurations
{
    public static class DependecyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            // Data
            services.AddScoped<DevIODbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            //Business
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
