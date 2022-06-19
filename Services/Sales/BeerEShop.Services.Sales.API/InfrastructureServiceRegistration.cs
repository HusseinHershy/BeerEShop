using BeerEShop.Services.Sales.API.Repositories;
using BeerEShop.Services.Wholesalers.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Sales.API
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SaleDbContext>(options =>
            options.UseSqlServer(connectionString));
            services.AddScoped<ISaleRepository, SaleRepository>();


            return services;
        }
    }
}
