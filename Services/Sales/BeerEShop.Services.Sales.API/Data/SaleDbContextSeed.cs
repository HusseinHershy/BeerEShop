using BeerEShop.Services.Sales.API.Data.Entities;
using BeerEShop.Services.Wholesalers.API.Data.Entities.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Wholesalers.API.Data
{
    public static class SaleDbContextSeed
    {
        public static async Task InitializeAsync(SaleDbContext wholesalerDbContext)
        {

            if (!wholesalerDbContext.Customers.Any())
            {
                wholesalerDbContext.Customers.AddRange(GetPreconfiguredCustomers());
                await wholesalerDbContext.SaveChangesAsync();
            }

        }
        private static IEnumerable<Customer> GetPreconfiguredCustomers()
        {
            return new List<Customer>
                {
                    new Customer("Olla","03752638","HOlla@gmail.com"),
                    new Customer("GeneDrinks","03752638","HOlla@gmail.com")
                   
                };
        }
   



    }
}
