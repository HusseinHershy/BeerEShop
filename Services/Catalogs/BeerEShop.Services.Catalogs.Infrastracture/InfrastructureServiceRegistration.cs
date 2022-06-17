using BeerEShop.Services.Catalogs.Application.Contract.Persistance;
using BeerEShop.Services.Catalogs.Infrastracture.Persistance;
using BeerEShop.Services.Catalogs.Infrastracture.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Infrastracture
{
   public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BeerCatalogContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
