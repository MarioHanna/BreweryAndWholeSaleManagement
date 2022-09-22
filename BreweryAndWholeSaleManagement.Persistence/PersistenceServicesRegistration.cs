using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using BreweryAndWholeSaleManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BreweryAndWholeSaleManagementDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("BreweryAndWholeSaleManagementConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IBeerRepository, BeerRepository>();
            services.AddScoped<IBreweryRepository, BreweryRepository>();
            services.AddScoped<IWholesalerRepository, WholesalerRepository>();
            services.AddScoped<IWholesalerStockRepository, WholesalerStockRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
